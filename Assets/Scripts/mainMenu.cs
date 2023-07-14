using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public AudioSource music;
    public GameObject mainMenuPanel, IntroPanel;
    public Image ImgIntro;
    
    private void Start()
    {
        music.Play();

    }
    public void StartGame()
    {
        StartCoroutine(IntroCo());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator IntroCo()
    {
        mainMenuPanel.SetActive(false);
        IntroPanel.SetActive(true); 


        yield return new WaitForSeconds(2f);

        ImgIntro.color = new Color(ImgIntro.color.r, ImgIntro.color.g, ImgIntro.color.b, Mathf.MoveTowards(ImgIntro.color.a, 1f, 1 * Time.deltaTime));

        SceneManager.LoadScene("Level1");
        music.Stop();


    }
}

