using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ghost : EnemiesMovement
{
    [SerializeField] Transform Point;
    [SerializeField] AudioSource audioSource;
    public UnityEvent SoundActivate;
    
    
    protected override void Update()
    {
        base.Update();
        rayCastGhost();
    }

    void rayCastGhost()
    {
        RaycastHit hit;
            if (Physics.Raycast(Point.position, Point.transform.TransformDirection(Vector3.forward), out hit, enemiesData.distance))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    SoundActivate?.Invoke();
                    //audioSource.Play();
                }
            }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = Point.transform.TransformDirection(Vector3.forward) * enemiesData.distance;
        Gizmos.DrawRay(Point.position, direction);
    }

}
