using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsCollision : MonoBehaviour
{
    EnemyHeal Enemylive;
    private void Start()
    {
           Enemylive = GetComponent<EnemyHeal>();
    }
    private void OnTriggerEnter(Collider other)      
    {
        if (other.tag == "Enemies")
        {
            Debug.Log("Le pegaste al esqueleto");

            Enemylive.Damage(10);

            if (Enemylive.Hp <= 0) 
            { 
                Destroy(other.gameObject);
            }
        }

    }
}
