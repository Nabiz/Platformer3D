using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCake : MonoBehaviour
{
  [SerializeField] private float rotateSpeed = 50.0f;

    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
    }
}
