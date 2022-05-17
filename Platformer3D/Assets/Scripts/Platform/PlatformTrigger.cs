using UnityEngine;

public class PlatformTrigger : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.transform.SetParent(transform);
            GetComponent<PlatformController>().SetPlayer(other.gameObject.GetComponent<PlayerController>());
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            other.transform.SetParent(null);
            GetComponent<PlatformController>().SetPlayer(null);
            other.GetComponent<PlayerController>().SetJumpHeight(0f, true);
        }
    }
}
