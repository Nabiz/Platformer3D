using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {
    [SerializeField] private List<Vector3> waypoints;
    [SerializeField] private float moveDuration = 2f;
    [SerializeField] private float stopDuration;

    private int _currentWaypoint;
    
    private void Start() {
        if (waypoints.Count > 1) {
            StartCoroutine(Move(waypoints[0], waypoints[1]));
        }
    }

    private IEnumerator Move(Vector3 beginPosition, Vector3 goalPosition) {
        float currentMoveDuration = 0f;
        while (currentMoveDuration < moveDuration) {
            transform.position = Vector3.Lerp(beginPosition, goalPosition, currentMoveDuration / moveDuration);
            currentMoveDuration += Time.deltaTime;
            yield return null;
        }
        
        yield return new WaitForSeconds(stopDuration);
        _currentWaypoint = (_currentWaypoint + 1) % waypoints.Count;
        StartCoroutine(Move(waypoints[_currentWaypoint], waypoints[(_currentWaypoint + 1) % waypoints.Count]));
    }
}
