using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : EnemiesMovement
{
    [SerializeField] Animator SkeletonRuning;
    [SerializeField] GameObject Point;

    protected override void Update()
    {
        base.Update();
        rayCastSkeleton();
    }

    protected override void move()
    {

        Vector3 Chase = (Player.transform.position - transform.position);
        if (Chase.magnitude > 4f && Player != null)
        {
            SkeletonRuning.SetBool("Runing", true);
            //transform.position += Chase.normalized * Time.deltaTime * enemiesData.velocidad;
            agente.destination = Player.transform.position;
        }
        else
        {
            agente.destination = transform.position;
            SkeletonRuning.SetBool("Runing", false);
        }
        
    }

    void rayCastSkeleton()
    {
        RaycastHit hit;
        if (Physics.Raycast(Point.transform.position, Point.transform.TransformDirection(Vector3.forward), out hit, enemiesData.distance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                SkeletonRuning.SetBool("atack", true);
                SkeletonRuning.Play("atack");
                //audioSource.Play();
                Invoke("DelayAtack", 1f);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = Point.transform.TransformDirection(Vector3.forward) * enemiesData.distance;
        Gizmos.DrawRay(Point.transform.position, direction);
    }

    void DelayAtack()
    {
        SkeletonRuning.SetBool("atack", false);
    }
}
