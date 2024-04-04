using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField]
    [Tooltip("The reference to the action of Jumping the XR Origin with this controller.")]
    InputActionReference m_Jump;

    public float jumpSpeed = 15f;
    public float gravity = 10.0f;
    private Vector3 movingDirection = Vector3.zero;
    private bool jumpPressed;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        m_Jump.action.performed += Jumping;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded && jumpPressed)
        {
            movingDirection.y = jumpSpeed;
            jumpPressed = false;
        }

        else
        {
            jumpPressed = false;
        }
        movingDirection.y -= gravity * Time.deltaTime;
    }

    private void Jumping(InputAction.CallbackContext obj)
    {
        
        jumpPressed = true;
    }
}
