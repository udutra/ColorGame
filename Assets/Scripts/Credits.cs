using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    public void RestartButton() {
        SceneManager.LoadScene(0);
    }

    public void CloseButton() {
        Application.Quit();
    }

}