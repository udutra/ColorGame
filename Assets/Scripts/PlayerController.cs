using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D playerRb;
    private SpriteRenderer playerSr;
    private string currentColor;
    [SerializeField] private Color orangeColor, violetColor, cyanColor, pinkColor;
    [SerializeField] private ParticleSystem playerParticles;
    [SerializeField] private float verticalForce = 400f;
    [SerializeField] private float restartDelay = 1f;

    private void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        playerSr = GetComponent<SpriteRenderer>();
        ChangeColor();
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(0, verticalForce));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("ColorChanger")) {
            ChangeColor();
            Destroy(collision.gameObject);
            return;
        }

        if (collision.gameObject.CompareTag("FinishLine")) {
            gameObject.SetActive(false);
            Instantiate(playerParticles, transform.position, Quaternion.identity);
            Invoke(nameof(LoadNextScene), restartDelay);
            return;
        }

        if (!collision.gameObject.CompareTag(currentColor)) {
            gameObject.SetActive(false);
            Instantiate(playerParticles, transform.position, Quaternion.identity);
            Invoke(nameof(RestartScene), restartDelay);
        }
    }

    private void ChangeColor() {
        int randomNumber = Random.Range(0, 4);

        switch (randomNumber) {
            case 0: {
                    playerSr.color = orangeColor;
                    currentColor = "Orange";
                    break;
                }
            case 1: {
                    playerSr.color = violetColor;
                    currentColor = "Violet";
                    break;
                }
            case 2: {
                    playerSr.color = cyanColor;
                    currentColor = "Cyan";
                    break;
                }
            case 3: {
                    playerSr.color = pinkColor;
                    currentColor = "Pink";
                    break;
                }
            default: {
                    playerSr.color = Color.white;
                    currentColor = "ErrorColor";
                    break;
                }
        }
    }

    private void RestartScene() {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }

    private void LoadNextScene() {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex + 1);
    }
}