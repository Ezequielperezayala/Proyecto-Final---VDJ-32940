using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private int Live = 50;
    public int HP { get { return Live; } }
    public void Healing(int Vida)
    {
        Live += Vida;
    }
}
