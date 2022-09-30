using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private int Live = 100;
    public int Hp { get { return Live; } }
    public void Healing(int Vida)
    {
        Live += Vida;
    }

    public void Damage(int Daño)
    {
        Live -= Daño;
    }
}
