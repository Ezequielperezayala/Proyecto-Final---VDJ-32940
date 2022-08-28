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

    [SerializeField] Transform Point;

    [SerializeField] [Range(5, 10)] float distance;

    bool canSpawn = true;

    /*private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InvokeRepeating("Enemy", StartTime, DelayTime);
        }
        
    }*/

    private void Update()
    {
        SpawnRayCasting();
    }

    void Enemy()
    {
        Instantiate(Enemigo, Spawn.transform);
    }

    void SpawnRayCasting()
    {
        RaycastHit hit;
        if (Physics.Raycast(Point.position, Point.transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            if (hit.transform.CompareTag("Player") && canSpawn)
            {
                Enemy();
                canSpawn = false;
                Invoke("DelaySpawn", 3f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = Point.transform.TransformDirection(Vector3.forward) * distance;
        Gizmos.DrawRay(Point.position, direction);
    }

    void DelaySpawn()
    {
        canSpawn = true;
    }
}
