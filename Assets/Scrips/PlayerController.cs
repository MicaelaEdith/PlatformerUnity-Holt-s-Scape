using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale = 5f;
    private bool jump = true;

    private Vector3 moveDirection;

    public CharacterController character;
    public Animator playerAnimator;
    public static PlayerController instance;
    public Camera mainCamera;


    public void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }


    void Update()
    {
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection = moveDirection * moveSpeed;
        moveDirection.y = yStore;

        if (character.isGrounded || jump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if(character.isGrounded)
                   moveDirection.y = jumpForce;
                if(!character.isGrounded && jump)
                {
                    jump = false;
                    moveDirection.y = jumpForce;
                }
            }

            if (character.isGrounded && !jump)
                jump = true;
            
        }


        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
        character.Move(moveDirection * Time.deltaTime);

        playerAnimator.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        playerAnimator.SetBool("IsGrounded", character.isGrounded);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, mainCamera.transform.rotation.eulerAngles.y, 0f);

        }

    }


}
