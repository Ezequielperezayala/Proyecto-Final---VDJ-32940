using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsCollision : MonoBehaviour
{
    EnemiesData enemiesData;
    public GameObject Enemies;
    private void Start()
    {
        Enemies = GameObject.Find("Skeleton");
        if(Enemies != null)
        {
           enemiesData = Enemies.GetComponent<EnemiesData>();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemies")
        {
            if (enemiesData.vida == 0) 
            { 
      
                Destroy(other.gameObject);
            }
            else
            {
                Debug.Log("Lepegaste al esqueleto");
                enemiesData.Damage(10);
            }

        }

    }
}
