using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool boolIsPlaceable;

    void OnMouseDown()
    {
        if (boolIsPlaceable)
        {
            Debug.Log(transform.name);
        }
    }
}
