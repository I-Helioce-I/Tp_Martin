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

    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.A))
        {
            camSelected--;


            transform.rotation = transform.rotation * Quaternion.Euler(0, +90, 0);

            if (camSelected <= 0)
            {
                camSelected = 3;
            }
            ActiveCamera();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            camSelected++;

            transform.localRotation = transform.localRotation * Quaternion.Euler(0, -90, 0);

            if (camSelected > 3)
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

        if (horizontalInput != 0)
        {
            if (horizontalInput > 0)
            {
                animator.SetFloat("Speed", horizontalInput);
            }
            else if(horizontalInput < 0)
            {
                animator.SetFloat("Speed", -horizontalInput);
            }
        }
        if(verticalInput != 0)
        {
            if(verticalInput > 0)
            {
                animator.SetFloat("Speed", verticalInput);
            }
            else if(verticalInput < 0)
            {
                animator.SetFloat("Speed", -verticalInput);
            }
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }


}
