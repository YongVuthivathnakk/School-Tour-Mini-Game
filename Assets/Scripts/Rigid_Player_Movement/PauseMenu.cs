using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    public GameObject container;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ResumeButton()
  {
    container.SetActive(false);
    Time.timeScale = 1;
    Cursor.lockState = CursorLockMode.Locked;
  }

  public void MainMenu()
  {
    SceneManager.LoadScene("MenuScene");
    Time.timeScale = 1;
  }
}
