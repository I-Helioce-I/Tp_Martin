using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevelElement : MonoBehaviour
{
    Vector3 target;
    bool inPlace = true;
    private void Start()
    {
        target = transform.position;
        transform.position = Vector3.down * 25;

        inPlace = false;
    }

    private void Update()
    {
        if (!inPlace)
        {

        }
    }

}
