using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
 
    private Vector3 respawnPosition;

    private void Awake()
    {
        instance = this;

    }
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        respawnPosition = PlayerController.instance.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Pause))
        {
          
            PausePanel();


        }
        
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    public IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        UIManager.instance.fadeToBlack = true;

        yield return new WaitForSeconds(2f);

        UIManager.instance.fadeFromBlack = true;
        PlayerController.instance.transform.position = respawnPosition;
        PlayerController.instance.gameObject.SetActive(true);
        HealthManager.instance.ResetHealth();

    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        respawnPosition = newSpawnPoint;

    }

    public void PausePanel()
    {

        if (UIManager.instance.pausePanel.activeInHierarchy)
        {
            UIManager.instance.pausePanel.SetActive(false);
            UIManager.instance.btnCloseOptions();
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }

        else
        {
            UIManager.instance.pausePanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (UIManager.instance.optionsPanel.activeInHierarchy)
        {
            UIManager.instance.pausePanel.SetActive(true);
            UIManager.instance.optionsPanel.SetActive(false);

        }
    }





}
