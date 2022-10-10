using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebolt : MonoBehaviour
{
    [SerializeField] int Velocidad;
    public int Damage;
    [SerializeField]
    [Range(1,5)]
    float LiveTime;


    // Start is called before the first frame update
    void Start()
    {
        DestroyBullet();
    }

    // Update is called once per frame
    void Update()
    {
        
        Movement();
    }

    void Movement()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Velocidad);
    }

    void DestroyBullet()
    {
        Destroy(gameObject, LiveTime);
    }


   
}
