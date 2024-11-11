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
    public FixedJoystick joystick;
    public Rigidbody hips;
    private Animator animator;
    private Vector3 lastCharacterPosition;
    private Quaternion lastCharacterRotation;
    public float positionLerpSpeed = 5f;
    public float rotationLerpSpeed = 5f;
    public float inertiaDamping = 0.9f;
    public CollectSpawn cs;
    public Rigidbody[] rbs;
    private List<Vector3> objectVelocities;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", false);
        objectVelocities = new List<Vector3>(rbs.Length);

        // Inicializa a velocidade de cada objeto na pilha como zero
        for (int i = 0; i < rbs.Length; i++)
        {
            objectVelocities.Add(Vector3.zero);
        }
        lastCharacterPosition = transform.position;
        lastCharacterRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Get Player Input
        horizontalInput = joystick.Horizontal;
        verticalInput = joystick.Vertical;
        // Movement the Player
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput);
        if (direction.magnitude >= 0.1f)
        {
            direction.Normalize();
            targetRotation = Quaternion.LookRotation(direction).eulerAngles;
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation.x, Mathf.Round(targetRotation.y / 45) * 45, targetRotation.z), Time.deltaTime * rotationSpeed);
            hips.AddForce(direction * speed);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false );
        }
        lastCharacterPosition = transform.position;
        lastCharacterRotation = transform.rotation;
        //MoveStack();
        //RotateStack();
    }

    private void MoveStack()
    {
        Vector3 characterMovement = transform.position - lastCharacterPosition;

        for (int i = 0; i < cs.collections.Length; i++)
        {
            Rigidbody stackRigidbody = rbs[i];

            // Define a posição de destino do objeto atual com um offset acima do objeto anterior
            Vector3 targetPosition = transform.position + Vector3.up * (i + 1);
            targetPosition += characterMovement * (1 - Mathf.Exp(-positionLerpSpeed * Time.deltaTime));

            // Calcula a nova velocidade aplicando inércia e desaceleração
            Vector3 velocity = (targetPosition - stackRigidbody.position) * positionLerpSpeed;
            objectVelocities[i] = Vector3.Lerp(objectVelocities[i], velocity, inertiaDamping);

            // Aplica a velocidade ao Rigidbody
            stackRigidbody.velocity = objectVelocities[i];
        }
    }

    private void RotateStack()
    {
        Quaternion characterRotation = transform.rotation * Quaternion.Inverse(lastCharacterRotation);

        for (int i = 0; i < cs.collections.Length; i++)
        {
            Rigidbody stackRigidbody = rbs[i];

            // Calcula a rotação com base no movimento do personagem
            Quaternion targetRotation = characterRotation * stackRigidbody.rotation;
            stackRigidbody.MoveRotation(Quaternion.Slerp(stackRigidbody.rotation, targetRotation, Time.deltaTime * rotationLerpSpeed / (i + 1)));
        }
    }
}
