using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBounce : MonoBehaviour
{
    [SerializeField] float jumpHeight = 5.0f;
    private Animator animator;
    private AudioSource audio;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerKick"))
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();
            player.SetJumpVelocity(jumpHeight);
            animator.SetTrigger("Kicked");
            audio.Play();
        }
    }
}
