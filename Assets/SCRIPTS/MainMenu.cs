using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public GameObject optionMenu;
  
    // Start is called before the first frame update
    public void PlayGame()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
       Cursor.lockState = CursorLockMode.Locked;
       
    }

    public void Options()
    {
        optionMenu.SetActive(true);
    }
    public void QuitGame()
    {
       Application.Quit();
    }
}
