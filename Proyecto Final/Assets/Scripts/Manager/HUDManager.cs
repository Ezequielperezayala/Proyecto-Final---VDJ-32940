using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

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
    }
}
