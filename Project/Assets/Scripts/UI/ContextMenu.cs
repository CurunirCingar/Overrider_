using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ContextMenu : MonoBehaviour {

    List<UI.Command> itemsList = new List<UI.Command>();

    public Action<UI.Command> OnItemSelected;
    public Action<bool> OnMenuActiveChange;

    [SerializeField]
    private RectTransform panelTransform;
    [SerializeField]
    private Dropdown menuDropdown;
    [SerializeField]
    private Button activateBugButton;

    public bool isShown;
    private Camera bindedCamera;
    private Transform bindedTransform;

    private void Awake()
    {
        SetActiveState(false);
        activateBugButton.onClick.AddListener(OnValueChange);
    }

    void SetActiveState(bool state)
    {
        isShown = state;
        menuDropdown.gameObject.SetActive(state);
        activateBugButton.gameObject.SetActive(state);
        if (OnMenuActiveChange != null)
            OnMenuActiveChange(state);
    }

    public void ShowMenu(List<UI.Command> itemsList, Camera cam, Transform trans)
    {
        this.itemsList = itemsList.ToList();
        bindedCamera = cam;
        bindedTransform = trans;
        panelTransform.position = Input.mousePosition;
      
        menuDropdown.options.Clear();
        foreach (var item in this.itemsList)
        {
            var dropdownItem = new Dropdown.OptionData(item.Caption + " - " + item.Cost);
            menuDropdown.options.Add(dropdownItem);
        }
        menuDropdown.value = 0;
        menuDropdown.captionText.text = itemsList[0].Caption + " - " + itemsList[0].Cost;

        SetActiveState(true);
    }

    public void CloseMenu()
    {
        SetActiveState(false);
    }

    private void Update()
    {
        //if (isShown)
        //{
        //    Vector3 viewPos = bindedCamera.WorldToScreenPoint(bindedTransform.position);
        //    panelTransform.position = viewPos;
        //}
    }

    void OnValueChange()
    {      
        Debug.Log("Value changed");
        if (itemsList.Count < menuDropdown.value)
        {
            Debug.Log("Items list is invalid!");
        }
        else
        {
            var item = itemsList[menuDropdown.value];
            if (OnItemSelected != null)
                OnItemSelected(item);
        }
        SetActiveState(false);
    }
}
