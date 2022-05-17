using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    [SerializeField] float jumpHeight = 10.0f;
    [SerializeField] Trampoline trampoline;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.SetJumpVelocity(jumpHeight);
            trampoline.PlayAnimation();
        }
    }
}
