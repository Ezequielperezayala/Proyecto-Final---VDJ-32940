using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int Live = 100;
    public int Hp { get { return Live; } }
    public void Healing(int Vida)
    {
        Live += Vida;
    }

    public void Damage(int Da�o)
    {
        Live -= Da�o;
    }
}
