using UnityEngine;

public class LeverTrigger : MonoBehaviour {
    private LeverController _leverRotate;
    
    private void Start() {
        _leverRotate = GetComponentInParent<LeverController>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PlayerKick")) {
            _leverRotate.StartRotation();
        }
    }
}
