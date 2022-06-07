using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] Animator trampolineAnimator;
    [SerializeField] AudioSource trampolineAudio;

    public void PlayAnimation()
    {
        trampolineAnimator.SetTrigger("Jump");
        trampolineAudio.Play();
    }
}
