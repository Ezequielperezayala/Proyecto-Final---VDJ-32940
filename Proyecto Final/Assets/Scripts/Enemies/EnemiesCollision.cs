using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemiesCollision : MonoBehaviour
{
    EnemyHeal EnemyLive;

    void Start()
    {
        EnemyLive = GetComponent<EnemyHeal>();
    }

    private void Update()
    {
        Debug.Log(EnemyLive.Hp);
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Weapons")
        {
            
            if(EnemyLive.Hp <= 0)
            {
                Destroy(gameObject);
            } else
            {
                Debug.Log("recibiste daño");
                EnemyLive.Damage(10);
            }
            
        }
        
    }
}
