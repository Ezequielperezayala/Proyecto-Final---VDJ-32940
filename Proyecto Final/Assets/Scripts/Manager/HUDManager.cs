using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    [SerializeField] Text Score;
    [SerializeField] Slider LifeBar;
    [SerializeField] GameObject deadScreen;

    




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            PlayerCollision.Ondead += GameOver;
            PlayerCollision.OnchangeHP += HealBar;
            PlayerCollision.OnPick += ViewScore;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        GameManager.Score = 0;

    }

    void Update()
    {
        
    }

    public void ViewScore(string newScore)
    {
        Score.text = newScore;
    }

    public static void HealBar(int HP)
    {
        instance.LifeBar.value = HP;
    }

    void GameOver()
    {
        deadScreen.SetActive(true);
        GameManager.Score = 0;
        HUDManager.instance.ViewScore("" + GameManager.Score);
    }

    public void OnclickRestart()
    {
        SceneManager.LoadScene(1);
        deadScreen.SetActive(false);
        
       
    }

    public void OnclickMenu()
    {
        SceneManager.LoadScene(0);
        deadScreen.SetActive(false);
    }

    
}
