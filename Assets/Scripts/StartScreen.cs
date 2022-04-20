using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {
    public void StartButton() {
        SceneManager.LoadScene(1);
    }
}