using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 Offset;
    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playerTransform.position;
    }

    private void LateUpdate()
    {
        transform.position = playerTransform.position + Offset;
    }
}
