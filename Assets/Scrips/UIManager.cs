using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image black;
    public float fadeSpeed;
    public bool fadeToBlack, fadeFromBlack;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        fadeFromBlack = true;
    }

    void Update()
    {
        if (fadeToBlack)
        {
            black.color = new Color(black.color.r,black.color.g,black.color.b,Mathf.MoveTowards(black.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (black.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }

        if (fadeFromBlack)
        {
            black.color = new Color(black.color.r, black.color.g, black.color.b, Mathf.MoveTowards(black.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (black.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }

    }
}
