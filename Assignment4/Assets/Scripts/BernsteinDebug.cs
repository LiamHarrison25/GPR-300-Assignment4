using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class BernsteinDebug : MonoBehaviour
{
    [SerializeField] private Transform p0;
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;
    [SerializeField] private Transform p3;
    [SerializeField] private Transform p;

    [SerializeField] private bool EnableGizmos = false;

    private void OnDrawGizmos()
    {
        if (EnableGizmos)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(p.position, p0.position);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(p.position, p1.position);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(p.position, p2.position);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(p.position, p3.position);
        }
    }
}
