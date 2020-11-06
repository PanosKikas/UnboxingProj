using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField]
    GameObject pausedMenu;  

    [SerializeField]
    AudioSource playerAudio;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void Resume()
    {
        TogglePauseMenu();
    }

    public void Quit()
    {
        Application.Quit();
    }


    void TogglePauseMenu()
    {
        pausedMenu.SetActive(!pausedMenu.activeSelf);

        bool pausedActive = pausedMenu.activeSelf;

        
        if (pausedActive)
        {
            playerAudio.mute = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            
            Cursor.visible = true;      
            
        }
        else
        {
            playerAudio.mute = false;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            
            Cursor.visible = false;
            
            
        }
        
    }

}
