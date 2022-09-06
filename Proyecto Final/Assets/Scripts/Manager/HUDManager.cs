using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    [SerializeField] Text Score;
    [SerializeField] Slider LifeBar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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

    public void ViewScore ( string newScore)
    {
        Score.text = newScore;
    }

    public static void HealBar(int HP)
    {
        instance.LifeBar.value = HP;
    }
}
