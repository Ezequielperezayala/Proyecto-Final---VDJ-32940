using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemiesCollision : MonoBehaviour
{
    private GameObject player;
    private PlayerData PlayerData;
    

    

    // Start is called before the first frame update

    void Start()
    {
        player = GameObject.Find("Player");
        if(player != null)
        {
            PlayerData = player.GetComponent<PlayerData>();
           
            
        }
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            Debug.Log("atacaste al player");
            if(PlayerData.Hp == 0)
            {
                PlayerData.Damage(0);
            } else
            {
                PlayerData.Damage(10);
            }
            
        }
        
    }
}
