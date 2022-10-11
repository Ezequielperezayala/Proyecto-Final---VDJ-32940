using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemiesCollision : MonoBehaviour
{
    [SerializeField] Animator Skeleton;
    [SerializeField] GameObject Puerta;
    [SerializeField] ActivacionSpawn ActivacionSpawn;

    public int HP = 100;
    public int damage = 10;

    private void Start()
    {
        Skeleton = GetComponent<Animator>();
        ActivacionSpawn = Puerta.GetComponent<ActivacionSpawn>();
        

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
      
        if (other.gameObject.tag == "Weapons")
        {
            HP -= damage;
            Skeleton.SetBool("Damage", true);
            Skeleton.Play("Damage");
            Invoke("DelayDamage", 0.5f);
            if (HP <= 0)
            {
                Destroy(gameObject);
                ActivacionSpawn.ContadorEnemies --;
                Debug.Log(ActivacionSpawn.ContadorEnemies);
            } 
            
        }
        
    }

    void DelayDamage()
    {
        Skeleton.SetBool("Damage", false);
    }




}
