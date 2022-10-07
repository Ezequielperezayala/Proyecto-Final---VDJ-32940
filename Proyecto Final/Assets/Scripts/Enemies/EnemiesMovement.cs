using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemiesMovement : MonoBehaviour
{
   
    //variable para determinar mediante el inspector el transform del player
    protected private GameObject Player;
    protected private NavMeshAgent agente;


    [SerializeField] protected EnemiesData enemiesData;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
        Invoke("move", 3f);  
        LookPlayer();
   
    }

    protected virtual void move()
    {
        transform.Translate(Vector3.forward * enemiesData.velocidad * Time.deltaTime);
    }

    //Metodo para mirar al jugador con Quaternions
    void LookPlayer()
    {
        Quaternion Look = Quaternion.LookRotation(Player.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, Look, 3f * Time.deltaTime);
    }

   

    
}
