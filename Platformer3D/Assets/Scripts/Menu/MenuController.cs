using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    [Header("Levels To Load")]

    public string _level1;
    public string _level2;
    public string _level3;
    public string _level4;
    public string _level5;

    public void Level1_run()
    {
        SceneManager.LoadScene(_level1);
    }

    public void Level2_run()
    {
        SceneManager.LoadScene(_level2);
    }

    public void Level3_run()
    {
        SceneManager.LoadScene(_level3);
    }

    public void Level4_run()
    {
        SceneManager.LoadScene(_level4);
    }

    public void Level5_run()
    {
        SceneManager.LoadScene(_level5);
    }

    public void ExitButton()
    {
        Application.Quit();
    } 
}
