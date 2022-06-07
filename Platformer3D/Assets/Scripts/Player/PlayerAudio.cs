using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioClip jumpAudio;
    [SerializeField] AudioClip kickAudio;

    private AudioSource playerAudio;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    public void PlayJumpSound()
    {
        playerAudio.PlayOneShot(jumpAudio);
    }
    public void PlayKickSound()
    {
        playerAudio.PlayOneShot(kickAudio);
    }
}
