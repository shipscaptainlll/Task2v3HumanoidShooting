using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PersonMovement : MonoBehaviour
{
    PlayerInput playerInput;
    [SerializeField] CharacterController characterController;
    [SerializeField] Transform cam;
    [SerializeField] Transform checkGround;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask checkLayer;
    [SerializeField] float gravity;
    [SerializeField] float speed;
    [SerializeField] float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    bool isGrounded;
    float verticalSpeed;


    [SerializeField] Animator characterAnimator;
    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputFromStick = playerInput.actions["Move"].ReadValue<Vector2>();

        float horizontal = inputFromStick.x;
        float vertical = inputFromStick.y;

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        isGrounded = (Physics.CheckSphere(checkGround.position, checkRadius, checkLayer));


        if (direction.magnitude >= 0.1f)
        {
            ChangeAnimationState("Run");

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);




            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            verticalSpeed -= gravity;
            if (isGrounded)
            {
                verticalSpeed = 0;
            }


            moveDirection.y = verticalSpeed;

            characterController.Move(moveDirection * speed * Time.deltaTime);
        } else
        {
            ChangeAnimationState("Idle");
        }

    }


    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        characterAnimator.CrossFade(newState, 0.1f, 0);

        currentState = newState;
    }

    public void PlayAttackAnimation()
    {
        characterAnimator.Play("Attack", 1, 0.1f);
    }

}
