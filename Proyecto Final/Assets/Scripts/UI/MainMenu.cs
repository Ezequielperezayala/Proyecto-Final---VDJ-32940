using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void onClickStart()
    {
        SceneManager.LoadScene(1);
        GameManager.Score = 0;
        HUDManager.instance.ViewScore("" + GameManager.Score);
    }

    public void onClickExit()
    {
        Application.Quit();
    }
}
