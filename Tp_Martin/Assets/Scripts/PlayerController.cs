using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    GameObject[] cams;
    [SerializeField]
    int camSelected;

    float horizontalInput;
    float verticalInput;

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.A))
        {
            camSelected--;

            if(camSelected <= 0)
            {
                camSelected = 3;
            }
                ActiveCamera();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            camSelected++;

            if (camSelected >3)
            {
                camSelected = 0;
            }
                ActiveCamera();
        }
    }

    private void ActiveCamera()
    {
        
        foreach (GameObject cam in cams)
        {
            cam.SetActive(false);
            cams[camSelected].SetActive(true);
        }
    }
    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        Debug.Log(moveDirection);

        transform.position += moveDirection * speed * Time.deltaTime;

    }


}
