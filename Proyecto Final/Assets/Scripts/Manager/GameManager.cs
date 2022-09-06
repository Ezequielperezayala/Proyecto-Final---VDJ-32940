using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Score;


    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Score = 0;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
