using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionSpawn : MonoBehaviour
{
    [SerializeField]
    BoxCollider puerta;

    [SerializeField]
    GameObject Enemigo;

    [SerializeField]
    [Range(1f, 10f)]
    float StartTime;

    [SerializeField]
    [Range(1f, 10f)]
    float DelayTime;

    [SerializeField]
    GameObject[] Spawn;

    [SerializeField] Transform Point;

    [SerializeField] [Range(5, 10)] float distance;

    bool canSpawn = true;


    private void Start()
    {
        
        puerta = GetComponent<BoxCollider>();
        puerta.enabled = false;
    }

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
        if (Enemigo == null)
        {
            puerta.enabled = false;
        }
        
    }

    void Enemy()
    {
        Instantiate(Enemigo, Spawn[0].transform);
        Instantiate(Enemigo, Spawn[1].transform);
        Instantiate(Enemigo, Spawn[2].transform);
        Instantiate(Enemigo, Spawn[3].transform);
        Instantiate(Enemigo, Spawn[4].transform);
        Instantiate(Enemigo, Spawn[5].transform);
        Instantiate(Enemigo, Spawn[6].transform);
        Instantiate(Enemigo, Spawn[7].transform);
    }

    void SpawnRayCasting()
    {
        RaycastHit hit;
        if (Physics.Raycast(Point.position, Point.transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            if (hit.transform.CompareTag("Player") && canSpawn)
            {
                puerta.enabled = true;
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
