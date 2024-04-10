using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private Casteljau casteljau;
    [SerializeField] private TestGizmos testGizmos;
    //[SerializeField] private GameObject connectedKnot;
    [SerializeField] private Transform controlPoint;
    [SerializeField] private Transform connectedControlPoint;
    //[SerializeField] private Vector3 controlPointDistance;
    [SerializeField] private int num;
    //[SerializeField] private GameObject gameObject;

    public bool isKnot = false;

    private bool isInControl = true;
    private bool isInCombinedState = false;

    private void SetControlState(bool state)
    {
        isInControl = state;
        testGizmos.ToggleGizmos(state);
    }

    public int GetPriority()
    {
        return casteljau.GetIdNumber();
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    public bool CheckIsCombined()
    {
        return isInCombinedState;
    }

    public int GetNum()
    {
        return num;
    }

    private void Update()
    {
        if (isKnot)
        {
            //TODO: Maybe have only one of the control points movable.
            Vector3 controlPointDistance = transform.position - controlPoint.position;
            Vector3 connectedControlPointDistance = transform.position - connectedControlPoint.position;

            if (controlPointDistance.magnitude != connectedControlPointDistance.magnitude) //check if the magnitude of the two control points is the same. 
            {
                //TODO: Mirror the tangent points
            }
        }
    }

    // private void CheckPriority(EndPoint endPoint)
    // {
    //     Debug.Log("CheckingPriority");
    //     int otherPriority = endPoint.GetPriority();
    //
    //     // if (otherPriority > casteljau.GetIdNumber())
    //     // {
    //     //    
    //     // }
    //     // else
    //     // {
    //     //     
    //     // }
    //
    //     if (otherPriority < casteljau.GetIdNumber()) //checks if it will be in control of the other object
    //     {
    //         Debug.Log("Checking if object can be controlled");
    //         connectedKnot = endPoint.GetGameObject();
    //         
    //         Debug.Log("Taking control of object");
    //         switch (endPoint.GetNum()) //Determines if the object is a left or right end point
    //         {
    //             case 0:
    //                 casteljau.SetControlledLeft(connectedKnot);
    //                 casteljau.SetOtherLeft(true);
    //                 break;
    //             case 1: 
    //                 casteljau.SetControlledRight(connectedKnot);
    //                 casteljau.SetOtherRight(true);
    //                 break;
    //         }
    //     }
    //     else //object will be controlled
    //     {
    //         Debug.Log("object has lost control");
    //         SetControlState(false);
    //         //TODO: tell the casteljau that it is no longer in control;
    //     }
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (!isInCombinedState)
    //     {
    //         if (other.CompareTag("EndPoint"))
    //         {
    //             Debug.Log(other.name);
    //             CheckPriority(other.GetComponent<EndPoint>());
    //             isInCombinedState = true;
    //         }
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (isInCombinedState)
    //     {
    //         if (other.CompareTag("EndPoint"))
    //         {
    //             if (!isInControl)
    //             {
    //                 SetControlState(true);
    //             }
    //             isInCombinedState = false;
    //         }
    //     }
    // }
}
