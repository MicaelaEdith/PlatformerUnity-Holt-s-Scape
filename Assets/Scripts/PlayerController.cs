using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public GameObject enemyTarget;  
    
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale = 5f;
    public bool slow = false;
    private bool jump = true;

    public Vector3 moveDirection;

    public CharacterController character;
    public Animator playerAnimator;
    public Camera mainCamera;
    public GameObject playerModel;


    public void Awake()
    {
        instance = this;
    }

    void Update()
    {
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection.Normalize();
        moveDirection = moveDirection * moveSpeed;
        moveDirection.y = yStore;

        if (character.isGrounded || jump)
        {
            if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1")) && !playerAnimator.GetBool("Slow") && !playerAnimator.GetBool("Bird"))
            {
                if (character.isGrounded)
                    moveDirection.y = jumpForce;
                if (!character.isGrounded && jump)
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
        playerAnimator.SetBool("Slow", slow);


        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
           
            transform.rotation = Quaternion.Euler(0f, mainCamera.transform.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, 6f * Time.deltaTime);


        }

    }


}
