using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject[] waitPoints;
    bool exit = false;

    private void Update()
    {
        if(exit)
            transform.position = Vector3.MoveTowards(transform.position, waitPoints[0].transform.position, 0.5f * Time.deltaTime);

        if (transform.position == waitPoints[0].transform.position)
            exit = false;


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.position = Vector3.MoveTowards(transform.position, waitPoints[1].transform.position, 3f * Time.deltaTime);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        exit = true;
    }

}
