using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject startMenu;
  public void StartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StartFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Load()
    {
        SaveSystem.playerLoad();
    }
    public void OpenStartMenu()
    {
        mainMenu.SetActive(false);
        startMenu.SetActive(true);
    }
    public void CloseStartMenu()
    {
        mainMenu.SetActive(true);
        startMenu.SetActive(false);
    }
}
