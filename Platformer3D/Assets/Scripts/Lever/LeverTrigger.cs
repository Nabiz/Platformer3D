using UnityEngine;

public class LeverTrigger : MonoBehaviour {
    private LeverController _leverController;
    
    private void Start() {
        _leverController = GetComponentInParent<LeverController>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PlayerKick")) {
            _leverController.StartRotation();
        }
    }
}
