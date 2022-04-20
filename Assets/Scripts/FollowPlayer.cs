using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [SerializeField] private Transform playerTransform;

    private void Update() {
        if (playerTransform.position.y > transform.position.y) {
            transform.position = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);
        }
    }
}