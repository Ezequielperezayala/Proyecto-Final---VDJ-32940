using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsCollision : MonoBehaviour
{
    [SerializeField] GameObject Enemie;
    EnemyHeal Enemylive;
    private void Start()
    {
           Enemylive = Enemie.GetComponent<EnemyHeal>();
    }
    private void OnTriggerEnter(Collider other)      
    {
        if (other.tag == "PowerUp")
        {
            Debug.Log("Le pegaste al esqueleto");
            Destroy(other.gameObject);

            /*Enemylive.Damage(10);

            if (Enemylive.Hp <= 0) 
            { 
                Destroy(other.gameObject);
            }*/
        }

    }
}
