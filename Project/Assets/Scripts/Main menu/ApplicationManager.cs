using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour {
	
  public void NewGame()
  {
    SceneManager.LoadScene("Level 1");
  }

  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void MainMenu() {
    SceneManager.LoadScene("Menu");
  }

	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
