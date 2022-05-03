using System;
using System.Collections;
using UnityEngine;

public class DoorOpener : OpenableAndCloseable {
    [SerializeField] private float openingDuration = 0.5f;
    [SerializeField] private AudioClip doorOpenFX;
    [SerializeField] private AudioClip doorCloseFX;

    private Transform _door;
    private AudioSource _audioSource;
    
    private readonly Quaternion _closedDoorRotation = Quaternion.Euler(0f, 0f, 0f);
    private readonly Quaternion _openedDoorRotation = Quaternion.Euler(0f, -90f, 0f);
    
    private void Start() {
        _door = transform.GetChild(0);
        _audioSource = GetComponent<AudioSource>();
    }

    public override void Open() {
        StartCoroutine(Rotate(_openedDoorRotation));
        _audioSource.PlayOneShot(doorOpenFX);
    }
    
    public override void Close() {
        StartCoroutine(Rotate(_closedDoorRotation));
        _audioSource.PlayOneShot(doorCloseFX);
    }
    
    private IEnumerator Rotate(Quaternion endRotation) {
        isMoving = true;
        Quaternion startRotation = _door.localRotation;
        float currentRotationDuration = 0f;
        while (currentRotationDuration < openingDuration) {
            _door.localRotation = Quaternion.Lerp(startRotation, endRotation, currentRotationDuration / openingDuration);
            currentRotationDuration += Time.deltaTime;
            yield return null;
        }

        isOpen = !isOpen;
        isMoving = false;
    }
}
