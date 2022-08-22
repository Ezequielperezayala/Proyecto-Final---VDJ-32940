using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] float Velocidad;
    private float cameraKey = 0f;
    private Vector3 playerDirection;
    
    [SerializeField] Transform Character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        AnimatePlayer();
        PlayerMovement();
    }

    void Direction(Vector3 Movement)
    {
        transform.Translate(Movement * Time.deltaTime * Velocidad);
    }

    void PlayerMovement()
    {
        playerDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) playerDirection += Vector3.forward;
       
        if (Input.GetKey(KeyCode.S)) playerDirection += Vector3.back;
       
        if (Input.GetKey(KeyCode.A)) playerDirection += Vector3.left;
       
        if (Input.GetKey(KeyCode.D)) playerDirection += Vector3.right;

        if (playerDirection != Vector3.zero) Direction(playerDirection);

    }

    void RotatePlayer()
    {
        cameraKey += Input.GetAxis("Mouse X");

        Quaternion newRotation = Quaternion.Euler(0, cameraKey, 0);
        Character.rotation = Quaternion.Lerp(Character.rotation, newRotation, 3f * Time.deltaTime);

    }

    private bool IsAnimation(string animName)
    {
        return playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }

    void AnimatePlayer()
    {
        bool forward = Input.GetKeyDown(KeyCode.W);
        bool back = Input.GetKeyDown(KeyCode.S);
        bool left = Input.GetKeyDown(KeyCode.A);
        bool right = Input.GetKeyDown(KeyCode.D);
       
        if (forward) playerAnimator.SetTrigger("Run");
        if (back) playerAnimator.SetTrigger("RunBack");
        if (left) playerAnimator.SetTrigger("RunLeft");
        if (right) playerAnimator.SetTrigger("RunRight");
       
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            if (!IsAnimation("Idle")) playerAnimator.SetTrigger("Idle");
        }
    }
}
