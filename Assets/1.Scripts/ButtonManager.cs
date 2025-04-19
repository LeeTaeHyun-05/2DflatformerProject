using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject HelpUI;
    

    // Start is called before the first frame update
    public void MenuOpen()
    {
        MenuUI.SetActive(true);
    }

    public void MenuClose()
    {
        MenuUI.SetActive(false);
    }
    public void HelpOpen()
    {
        HelpUI.SetActive(true);
    }

    public void HelpClose()
    {
        HelpUI.SetActive(false);
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void GameQuit()
    {
        Application.Quit();
        Debug.Log("게임 종료");
    }
    
   

   
}
