using DG.Tweening;
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
    GameObject camActive;

    [SerializeField]
    GameObject body;

    Animator animator;
    Rigidbody rb;

    bool canMove;
    bool camMovement;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        canMove = true;
        camMovement = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

        camActive = cams[camSelected];

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

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.Translate(move * speed * Time.deltaTime, Space.Self);

        float moveAmount = Mathf.Clamp01(Mathf.Abs(move.x) + Mathf.Abs(move.z));

        animator.SetFloat("Speed", moveAmount);


        if (Input.GetKey(KeyCode.Z))
        {
            body.transform.rotation = Quaternion.Slerp(body.transform.rotation, Quaternion.LookRotation(camActive.transform.forward), 0.15f);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.transform.rotation = Quaternion.Slerp(body.transform.rotation, Quaternion.LookRotation(-camActive.transform.forward), 0.15f);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            body.transform.rotation = Quaternion.Slerp(body.transform.rotation, Quaternion.LookRotation(-camActive.transform.right), 0.15f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            body.transform.rotation = Quaternion.Slerp(body.transform.rotation, Quaternion.LookRotation(camActive.transform.right), 0.15f);
        }
    }


}
