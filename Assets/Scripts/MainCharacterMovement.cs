using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 10f;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 targetRotation;
    Animator animator;
    public FixedJoystick joystick;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get Player Input
        horizontalInput = joystick.Horizontal;
        verticalInput = joystick.Vertical;
        // Movement the Player
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput);
        if(direction.magnitude >= 0.1f)
        {
            direction.Normalize();
            targetRotation = Quaternion.LookRotation(direction).eulerAngles;
            rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation.x, Mathf.Round(targetRotation.y / 45)*45, targetRotation.z), Time.deltaTime * rotationSpeed);
            rb.velocity = direction * speed * Time.deltaTime;
            animator.SetBool("isWalking", true);
        }   
        else
        {
            animator.SetBool("isWalking", false);
            rb.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
