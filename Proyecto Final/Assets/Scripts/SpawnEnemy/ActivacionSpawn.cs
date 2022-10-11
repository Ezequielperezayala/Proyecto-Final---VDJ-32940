using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using TMPro;

public class ActivacionSpawn : MonoBehaviour
{
    [SerializeField]
    BoxCollider puerta;

    [SerializeField]
    GameObject Enemigo;

    [SerializeField]
    GameObject boss;

    [SerializeField]
    [Range(1f, 10f)]
    float StartTime;

    [SerializeField]
    [Range(1f, 10f)]
    float DelayTime;

    [SerializeField]
    GameObject[] Spawn;

    [SerializeField]
    GameObject spawnBoss;

    [SerializeField] Transform Point;

    [SerializeField] [Range(0, 10)] float distance;

    bool canSpawn = true;

    [SerializeField] float Timer;
    [SerializeField] TextMeshProUGUI contador;
    [SerializeField] bool Comienzo;

    public int ContadorEnemies = 0;

    

    private void Start()
    {
        puerta = GetComponent<BoxCollider>();
        puerta.enabled = false;
        Comienzo = false; 
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
        if (Comienzo == true)
        {
            Contador();
        }

        
        
    }

    void Enemy()
    {
        for(int i = 0; i < 9; i++)
        {
            Instantiate(Enemigo, Spawn[i].transform);
        }
        /*Instantiate(Enemigo, Spawn[0].transform);
        Instantiate(Enemigo, Spawn[1].transform);
        Instantiate(Enemigo, Spawn[2].transform);
        Instantiate(Enemigo, Spawn[3].transform);
        Instantiate(Enemigo, Spawn[4].transform);
        Instantiate(Enemigo, Spawn[5].transform);
        Instantiate(Enemigo, Spawn[6].transform);
        Instantiate(Enemigo, Spawn[7].transform);*/
       
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
                Comienzo = true;
                
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

    void Contador()
    {
        Timer -= Time.deltaTime;
        contador.text = "" + Timer.ToString("f0");
        if (Timer <= 0)
        {
          Timer = 0;
        }
    }
    
}
