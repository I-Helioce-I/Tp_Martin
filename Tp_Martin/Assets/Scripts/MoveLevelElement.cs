using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevelElement : MonoBehaviour
{
    [SerializeField]
    float direction;

    [SerializeField]
    bool inPlace;
    [SerializeField]
    public Vector3 target;
    [SerializeField]
    float speed;

    private void OnEnable()
    {
        inPlace = true;

        target = transform.position;
        transform.position = Vector3.zero + new Vector3(transform.position.x, transform.position.y + direction, transform.position.z);
    }

    public void SetInPlaceBool()
    {
        inPlace = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlace)
        {
            transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);

            if (transform.position.y == target.y)
            {
                inPlace = true;
            }
        }
    }

}
