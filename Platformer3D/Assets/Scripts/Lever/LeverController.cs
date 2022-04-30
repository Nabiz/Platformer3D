using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeverController : MonoBehaviour {
    [SerializeField] private List<OpenableAndCloseable> doorList;
    [SerializeField] private float movingDuration = 0.7f;

    private readonly Quaternion _startPositionRotation = Quaternion.Euler(0f, 0f, 0f);
    private readonly Quaternion _endPositionRotation = Quaternion.Euler(0f, 0f, 100f);
    
    private Transform _handlePivot;
    private AudioSource _audioSource;

    private bool _isInStartPosition = true;
    private bool _isRotating;

    private void Start() {
        _handlePivot = transform.GetChild(0);
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartRotation() {
        if (!_isRotating && !doorList.Any(p => p.isMoving)) {
            if (!_isInStartPosition)
                StartCoroutine(Rotate(_startPositionRotation));
            else
                StartCoroutine(Rotate(_endPositionRotation));

            _isRotating = true;
        }
    }
    
    private IEnumerator Rotate(Quaternion endRotation) {
        _audioSource.Play();
        
        Quaternion startRotation = _handlePivot.localRotation;
        float currentRotationDuration = 0f;
        while (currentRotationDuration < movingDuration) {
            _handlePivot.localRotation = Quaternion.Lerp(startRotation, endRotation, currentRotationDuration / movingDuration);
            currentRotationDuration += Time.deltaTime;
            yield return null;
        }
       
        RotationFinished();
    }

    private void RotationFinished() {
        _isInStartPosition = !_isInStartPosition;
        _isRotating = false;
        
        ChangeDoorState();
    }

    private void ChangeDoorState() {
        foreach (OpenableAndCloseable door in doorList) {
            if (door.isOpen) 
                door.Close();
            else 
                door.Open();
        }
    }
}