using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int pointValue;
    public int sfx;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (other.tag == "Player")
        {
            PointsManager.instance.addPoints(pointValue);
            AudioManager.instance.PlaySFX(sfx);

        }
    }
}
