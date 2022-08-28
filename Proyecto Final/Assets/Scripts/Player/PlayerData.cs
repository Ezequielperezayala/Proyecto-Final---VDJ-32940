using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    int Live = 50;
    public void Healing(int Vida)
    {
        Live += Vida;
    }
}
