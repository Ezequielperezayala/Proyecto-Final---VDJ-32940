using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : EnemiesMovement
{
    [SerializeField] Animator SkeletonRuning;
   

    protected override void move()
    {

        Vector3 Chase = (Player.transform.position - transform.position);
        if (Chase.magnitude > 2f && Player != null)
        {
            SkeletonRuning.SetBool("Runing", true);
            transform.position += Chase.normalized * Time.deltaTime * enemiesData.velocidad;
        }
        else
        {
            SkeletonRuning.SetBool("Runing", false);
        }

    }
}
