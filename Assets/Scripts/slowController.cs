using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowController : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.slow = true;
            PlayerController.instance.moveSpeed = 1.5f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerController.instance.slow = false;
        PlayerController.instance.moveSpeed = 20f;
    }
}
