using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float smoothTime = 0.1f;
    public CharacterController controller;
    public Transform cam;
    float smoothVelocity;
    private float horizontalInput;
    private float verticalInput;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", false);
    }

    // Update is called once per frame
    void Update()
    {
        // Get Player Input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        // Movement the Player
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput);
        if(direction.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            if (Input.GetKey(KeyCode.S)) targetAngle -= 180;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            cam.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
