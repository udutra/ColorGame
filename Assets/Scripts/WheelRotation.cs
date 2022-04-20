using UnityEngine;

public class WheelRotation : MonoBehaviour {

    [SerializeField] private float rotationSpeed = 100f;

    private void Update() {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }
}