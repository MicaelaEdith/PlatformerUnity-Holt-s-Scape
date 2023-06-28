using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public int Speed;
    public bool Quiet;
    public bool Atack;
    bool startAnim = true, startQuiet=false;

    public Animator birdAnimator;
    public CharacterController character;
    

    private Vector3 moveDirection;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(startAnim&&!startQuiet)
        {
            moveDirection.z = transform.position.z + 0.00000001f;
            character.Move(moveDirection * Time.deltaTime);

            if (transform.position.z >= 200 && !startQuiet)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                startQuiet = true;
            }
        }
        if (startAnim&&startQuiet)
        {

            //moveDirection.y = transform.position.y - 0.00000001f;
            moveDirection.z = transform.position.z - 0.00000001f;
            Debug.Log(transform.position.z);

            character.Move(moveDirection * Time.deltaTime);
        }

               //startAnim = false;
    }


}
