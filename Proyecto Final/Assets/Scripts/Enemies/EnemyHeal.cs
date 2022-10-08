using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeal : MonoBehaviour
{
    [SerializeField]
    private int Live = 100;
    public int Hp { get { return Live; } }

    public void Damage(int Daño)
    {
        Live -= Daño;
    }
}
