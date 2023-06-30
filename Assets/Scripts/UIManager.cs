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
    public Text pointsText;
    public Text healthText;
    public GameObject pausePanel, optionsPanel;

    public Slider musicSlider, sfxSlider;
   

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

        pointsText.text = PointsManager.instance.points.ToString();
        setHealthUI(HealthManager.instance.health);

    }

    public void setHealthUI(int health)
    {

        if (health == 1)
            healthText.text = "♥";
        if (health == 2)
            healthText.text = "♥♥";
        if (health == 3)
            healthText.text = "♥♥♥";
        if (health == 4)
            healthText.text = "♥♥♥♥";
        if (health == 5)
            healthText.text = "♥♥♥♥♥";
    }

    public void btnResume()
    {
        GameManager.instance.PausePanel();

    }

    public void btnOptions()
    {
       
        optionsPanel.SetActive(true);
        pausePanel.SetActive(false);

    }

    public void setMusic()
    {
        AudioManager.instance.setMusic();

    }

    public void setSfx()
    {
        AudioManager.instance.setSfx();
    }

    public void btnCloseOptions()
    {
        GameManager.instance.PausePanel();
        

    }
    

    public void btnQuit()
    {
        
    }
}

