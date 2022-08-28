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

    [SerializeField] GameObject detectPoint;

    [SerializeField]
    [Range(10, 20)]
    float Distance;

    private bool canSpawn = true;

    /*private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InvokeRepeating("Enemy", StartTime, DelayTime);
        }
        
    }*/

    private void Update()
    {
        SpawnRayCast();
    }

    void Enemy()
    {
        Instantiate(Enemigo, Spawn.transform);
    }

    void SpawnRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(detectPoint.transform.position, detectPoint.transform.TransformDirection(Vector3.forward), out hit, Distance))
        {
            if (hit.transform.CompareTag("Player") && canSpawn)
            {
                Debug.Log("collision con la puerta");
                //InvokeRepeating("Enemy", StartTime, DelayTime);
                Enemy();
                canSpawn = false;
                Invoke("DelaySpawn", 3f);
            }


        }
    }

    void DelaySpawn()
    {
        canSpawn = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = detectPoint.transform.TransformDirection(Vector3.forward) * Distance;
        Gizmos.DrawRay(detectPoint.transform.position, direction);
    }
}
