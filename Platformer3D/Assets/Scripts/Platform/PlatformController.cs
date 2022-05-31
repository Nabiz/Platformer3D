using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {
    [SerializeField] private List<Vector3> waypoints;
    [SerializeField] private float moveDuration = 2f;
    [SerializeField] private float stopDuration;

    private int _currentWaypoint;

    private Vector3 platformVelocity = Vector3.zero;

#nullable enable
    private PlayerController? player = null;
#nullable disable


    private void Start() {
        if (waypoints.Count > 1) {
            StartCoroutine(Move(waypoints[0], waypoints[1]));
        }
    }

    public void SetPlayer(PlayerController player)
    {
        this.player = player;
    }

    private IEnumerator Move(Vector3 beginPosition, Vector3 goalPosition) {
        float currentMoveDuration = 0f;
        platformVelocity = (goalPosition - beginPosition) / moveDuration;
        while (currentMoveDuration < moveDuration) {
            if (player && platformVelocity.y > 0.01f)
            {
                player.SetJumpHeight(platformVelocity.y * platformVelocity.y / 12f, true);
            }
            transform.position = Vector3.Lerp(beginPosition, goalPosition, currentMoveDuration / moveDuration);
            currentMoveDuration += Time.deltaTime;
            yield return null;
        }
        platformVelocity = Vector3.zero;
        if (player)
        {
            player.SetJumpHeight(0f, true);
        }
        yield return new WaitForSeconds(stopDuration);
        _currentWaypoint = (_currentWaypoint + 1) % waypoints.Count;
        StartCoroutine(Move(waypoints[_currentWaypoint], waypoints[(_currentWaypoint + 1) % waypoints.Count]));
    }
}
