using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGizmo : MonoBehaviour
{
    [SerializeField] private float SphereSize;
    [SerializeField] private Color color;
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, SphereSize);
    }
}
