using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Invector.CharacterController;

public class PauseMenu : MonoBehaviour {

  private bool isPause;
  private GameObject canvas;
  [SerializeField] private Camera cam;
  [SerializeField] private vThirdPersonCamera vThirdPersonController;

  private void Start() {
    isPause = false;
    canvas = transform.GetChild(0).gameObject;
    canvas.SetActive(false);
  }

  private void Update() {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      Debug.Log("Escape downed");
      isPause = !isPause;
       if (isPause) {
        cam.gameObject.SetActive(false);
        cam.gameObject.SetActive(true);
        //GameRegimeManager.Instance.timeManager.SetTimeFreeze(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        canvas.SetActive(true);
        vThirdPersonController.enabled = false;
      }  else {
        Time.timeScale = 1;
        //GameRegimeManager.Instance.timeManager.SetTimeFreeze(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        canvas.SetActive(false);
        vThirdPersonController.enabled = true;
      }
      }
  }

  public void Restart() {
    Debug.Log("RESTART");
    GameRegimeManager.Instance.timeManager.SetTimeFreeze(false);
    canvas.SetActive(false);
    isPause = !isPause;
    Time.timeScale = 1;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void MainMenu() {
    Debug.Log("MainMenu");
    GameRegimeManager.Instance.timeManager.SetTimeFreeze(false);
    canvas.SetActive(false);
    isPause = !isPause;
    Time.timeScale = 1;
    SceneManager.LoadScene("Menu");
  }
}
