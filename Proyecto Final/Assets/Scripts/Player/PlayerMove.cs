using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float Velocidad;
    private float cameraKey = 0f;

    [SerializeField] Transform Character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        PlayerMovement();
    }

    void Direction(Vector3 Movement)
    {
        transform.Translate(Movement * Time.deltaTime * Velocidad);
    }

    void PlayerMovement()
    {

        if (Input.GetKey(KeyCode.W))
        {
            Direction(Vector3.forward);

        }

        if (Input.GetKey(KeyCode.S))
        {
            Direction(Vector3.back);

        }

        if (Input.GetKey(KeyCode.A))
        {
            Direction(Vector3.left);

        }

        if (Input.GetKey(KeyCode.D))
        {
            Direction(Vector3.right);

        }

    }

    void RotatePlayer()
    {
        //cameraAxis += Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            cameraKey -= 1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            cameraKey += 1;
        }

        //transform.rotation = Quaternion.Euler(0, cameraAxis, 0);

        Character.rotation = Quaternion.Euler(0, cameraKey, 0);
    }
}
