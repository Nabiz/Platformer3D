using UnityEngine;
using UnityEngine.Events;

public class SightRange : MonoBehaviour
{
    public UnityEvent playerEnteredSightRange;
    public UnityEvent playerLeftSightRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEnteredSightRange.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerLeftSightRange.Invoke();
        }
    }
}
