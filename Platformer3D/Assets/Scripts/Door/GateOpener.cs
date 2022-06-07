using System.Collections;
using UnityEngine;

public class GateOpener : OpenableAndCloseable {
    [SerializeField] private float openingDuration = 0.5f;
    [SerializeField] private AudioClip gateOpenFX;
    [SerializeField] private AudioClip gateCloseFX;

    private Transform _gate;
    private AudioSource _audioSource;

    private readonly Vector3 _closedGatePosition = new Vector3(-2.88f, 0f, -8.18f);
    private readonly Vector3 _openedGatePosition = new Vector3(-2.88f, 4.5f, -8.18f);
    
    private void Start() {
        _gate = transform.GetChild(0);
        _audioSource = GetComponent<AudioSource>();
    }
    
    public override void Open() {
        StartCoroutine(Move(_openedGatePosition));
        _audioSource.PlayOneShot(gateOpenFX);
    }
    
    public override void Close() {
        StartCoroutine(Move(_closedGatePosition));
        _audioSource.PlayOneShot(gateCloseFX);
    }
    
    private IEnumerator Move(Vector3 endPosition) {
        isMoving = true;
        Vector3 startPosition = _gate.localPosition;
        float currentMoveDuration = 0f;
        while (currentMoveDuration < openingDuration) {
            _gate.localPosition = Vector3.Lerp(startPosition, endPosition, currentMoveDuration / openingDuration);
            currentMoveDuration += Time.deltaTime;
            yield return null;
        }

        isOpen = !isOpen;
        isMoving = false;
    }
}
