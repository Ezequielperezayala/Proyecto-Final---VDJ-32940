using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemiesCollision : MonoBehaviour
{
    [SerializeField] Animator Skeleton;

    public int HP = 100;
    public int damage = 10;

    private void Start()
    {
        Skeleton = GetComponent<Animator>();
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
            
            Debug.Log(HP);

            if (HP <= 0)
            {
                Destroy(gameObject, 1f);
            } 
            
        }
        
    }

    void DelayDamage()
    {
        Skeleton.SetBool("Damage", false);
    }




}
