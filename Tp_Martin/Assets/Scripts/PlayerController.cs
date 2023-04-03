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

    bool canMove;
    bool camMovement;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        canMove = true;
        camMovement = true;
    }

    private void Update()
    {
        if (canMove)
        {
            Move();

        }

        if (Input.GetKeyDown(KeyCode.A) && camMovement)
        {
            StartCoroutine(CamMoving());
            camSelected--;


            transform.rotation = transform.rotation * Quaternion.Euler(0, +90, 0);

            if (camSelected <= 0)
            {
                camSelected = 3;
            }
            ActiveCamera();
        }
        else if (Input.GetKeyDown(KeyCode.E) && camMovement)
        {
            StartCoroutine(CamMoving());
            camSelected++;

            transform.localRotation = transform.localRotation * Quaternion.Euler(0, -90, 0);

            if (camSelected > 3)
            {
                camSelected = 0;
            }
            ActiveCamera();
        }
    }

    IEnumerator CamMoving()
    {
        canMove = false;
        camMovement = false;
        yield return new WaitForSeconds(2);
        camMovement = true;
        canMove = true;
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
            else if (horizontalInput < 0)
            {
                animator.SetFloat("Speed", -horizontalInput);
            }
        }
        if (verticalInput != 0)
        {
            if (verticalInput > 0)
            {
                animator.SetFloat("Speed", verticalInput);
            }
            else if (verticalInput < 0)
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
