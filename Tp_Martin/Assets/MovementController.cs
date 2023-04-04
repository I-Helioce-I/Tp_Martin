using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementController : MonoBehaviour
{
    [Header("Speed")]
    private float moveSpeed;
    public float walkSpeed;
    private float desiredMoveSpeed;
    private float lastDesiredMoveSpeed;


    float horizontalInput;
    float verticalInput;

    public Transform orientation;
    Vector3 moveDirection;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }
    private void Update()
    {
        MyInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }
    
    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }


    void MovePlayer()
    {
        Debug.Log("Should move");
        // Calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

    }
}
