using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject Enemigo;

    [SerializeField]
    [Range(1f, 10f)]
    float StartTime;

    [SerializeField]
    [Range(1f, 10f)]
    float DelayTime;

    [SerializeField]
    Transform Spawn;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InvokeRepeating("Enemy", StartTime, DelayTime);
        }
        
    }


    void Enemy()
    {
        Instantiate(Enemigo, Spawn.transform);
    }
}
