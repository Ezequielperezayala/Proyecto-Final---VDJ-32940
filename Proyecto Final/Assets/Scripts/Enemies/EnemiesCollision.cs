using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemiesCollision : MonoBehaviour
{
    EnemiesData enemiesData;




    // Start is called before the first frame update

    void Start()
    {
        enemiesData = GetComponent<EnemiesData>();
    }

    private void Update()
    {
        Debug.Log(enemiesData.vida);
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Weapons")
        {
            Debug.Log("recibiste daño");
            if(enemiesData.vida == 0)
            {
                Destroy(gameObject);
            } else
            {
                enemiesData.Damage(10);
            }
            
        }
        
    }
}
