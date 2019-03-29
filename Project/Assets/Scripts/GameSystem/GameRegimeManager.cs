using GameSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameRegimeManager : MonoBehaviour
{
    private static GameRegimeManager instance;
    public static GameRegimeManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameRegimeManager>();
            }
            return instance;
        }
    }
    public enum GameRegimeState
    {
        Action,
        Strategic,
    }
    public GameRegimeState currentRegimeState = GameRegimeState.Action;

    public Action<bool> OnShowInteractable;

    public TimeManager timeManager;
    public vThirdPersonCamera personCamera;
    public Invector.CharacterController.vThirdPersonInput personInput;
    public Invector.CharacterController.vThirdPersonController personController;
    public ContextMenu actionMenu;
    public EnergyBalanceManager balanceManager;
    public CameraEffectsManager cameraManager;

    public Material standardMaterial;
    public Material glitchMaterial;
    public Material interactableMaterial;
    public Text hackingRegimeText;

    public Material CurrentStandardMaterial
    {
        get
        {
            return currentRegimeState == GameRegimeState.Strategic ? 
                interactableMaterial : standardMaterial;
        }
    }   

    // Use this for initialization
    void Start ()
    {
        hackingRegimeText.enabled = false;

        actionMenu.OnMenuActiveChange += delegate (bool state)
        {
            personCamera.smoothCameraRotation = state ? 0 : 120;
        };

        actionMenu.OnItemSelected += delegate (UI.Command com)
        {
            if (balanceManager.ConsumeBalance(com.Cost))
            {
                com.Activate();
            }
            else
            {
                DialogueManager.instance.ShowText("Not enoth computing power");
            }
        };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            ChangeGameRegime();

        if(currentRegimeState == GameRegimeState.Strategic && 
            Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            var layerIndex = 1 << LayerMask.NameToLayer("Interactable");
            if (!actionMenu.isShown && Physics.Raycast(ray, out hit, 100, layerIndex))
            {
                var go = hit.collider.gameObject;
                var gameObjName = go.name;
                print("Hit " + gameObjName);
                var interactableObj = go.GetComponent<InteractableObject>();
                if (interactableObj != null)
                {
                    actionMenu.ShowMenu(interactableObj.Commands, personCamera._camera, go.transform);
                }
            }
            //else
            //{
            //    actionMenu.CloseMenu();
            //}
        }
    }

    private void ChangeGameRegime()
    {
        currentRegimeState = currentRegimeState == GameRegimeState.Action ?
            GameRegimeState.Strategic : GameRegimeState.Action;

        switch (currentRegimeState)
        {
            case GameRegimeState.Action:
                cameraManager.SetHackMode(false);
                hackingRegimeText.enabled = false;
                timeManager.SetTimeFreeze(false);
                personCamera.smoothCameraRotation = 12;
                personInput.keepDirection = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                actionMenu.CloseMenu();
                break;

            case GameRegimeState.Strategic:
                cameraManager.SetHackMode(true);
                hackingRegimeText.enabled = true;
                StartCoroutine(BlinkRegimeText());
                timeManager.SetTimeFreeze(true);
                personCamera.smoothCameraRotation = 12;
                personInput.keepDirection = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                break;
        }

        if (OnShowInteractable != null)
            OnShowInteractable(currentRegimeState == GameRegimeState.Strategic);
    }

    IEnumerator BlinkRegimeText()
    {
        while (currentRegimeState == GameRegimeState.Strategic)
        {
            for (float white = 0; white <= 1 && currentRegimeState == GameRegimeState.Strategic; white += 0.01f)
            {
                hackingRegimeText.color = new Color(white, white, white, white);
                yield return new WaitForEndOfFrame();
            }

            for (float white = 1f; white >= 0 && currentRegimeState == GameRegimeState.Strategic; white -= 0.01f)
            {
                hackingRegimeText.color = new Color(white, white, white, white);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
