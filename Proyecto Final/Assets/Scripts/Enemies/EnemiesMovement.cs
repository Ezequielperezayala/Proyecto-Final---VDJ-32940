using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    //creo variable enmu para diferenciar el movimiento de los enemigos en el juego
    enum EnemysTypes { Ghost, Skeleton }
    //variable para determinar mediante inspector que tipo de enemigo es
    [SerializeField] EnemysTypes EnemyType;
    //variable para determinar mediante el inspector el transform del player
    GameObject Player;
    [SerializeField]
    [Range(1,10)]
    float Velocidad;
    [SerializeField] Animator SkeletonRuning;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject detectPoint;
    [SerializeField]
    [Range(10,20)]
    float Distance;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (EnemyType)
        {
            case EnemysTypes.Ghost:
                LookPlayer();
                PhantomRayCast();
                break;
            case EnemysTypes.Skeleton:
                Invoke("ChasePlayer", 3f);
                break;
        }
    }

    //Metodo para que el enemiga siga al player
    void ChasePlayer()
    {

        Vector3 Chase = (Player.transform.position - transform.position);
        if (Chase.magnitude > 2f && Player != null)
        {
            SkeletonRuning.SetBool("Runing",true);
            LookPlayer();
            transform.position += Chase.normalized * Time.deltaTime * Velocidad;
        } else
        {
            SkeletonRuning.SetBool("Runing", false);
        }

    }

    //Metodo para mirar al jugador con Quaternions
    void LookPlayer()
    {
        Quaternion Look = Quaternion.LookRotation(Player.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, Look, 3f * Time.deltaTime);
    }

    void PhantomRayCast()
    {
        RaycastHit hit;
        if(Physics.Raycast(detectPoint.transform.position, detectPoint.transform.TransformDirection(Vector3.forward), out hit, Distance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("collision");
                audioSource.Play();
            }
            

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = detectPoint.transform.TransformDirection(Vector3.forward) * Distance;
        Gizmos.DrawRay(detectPoint.transform.position, direction);
    }
}
