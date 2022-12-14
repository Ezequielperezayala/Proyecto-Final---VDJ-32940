using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    
    [SerializeField] GameObject munition;
    private bool canShoot = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }

    }


    private void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            Instantiate(munition, transform.position, transform.rotation);
            Invoke("ResetShoot", 0.5f);
        }
    }

    private void ResetShoot()
    {
        canShoot = true;
    }
}
