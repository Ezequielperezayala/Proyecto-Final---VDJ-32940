using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCC : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] float Velocidad;
    private float cameraKey = 0f;
    private Vector3 playerDirection;
    private CharacterController PlayerCC;
    [SerializeField] Transform Character;


    // Start is called before the first frame update
    void Start()
    {
        PlayerCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatePlayer();
        PlayerMovement();
        RotatePlayer();
    }

    void Direction(Vector3 Movement)
    {
        PlayerCC.Move(transform.TransformDirection(Movement)* Time.deltaTime * Velocidad);
    }

    void PlayerMovement()
    {

        if (Input.GetKey(KeyCode.W)) Direction(Vector3.forward);
        if (Input.GetKey(KeyCode.S)) Direction(Vector3.back);
        if (Input.GetKey(KeyCode.A)) Direction(Vector3.left);
        if (Input.GetKey(KeyCode.D)) Direction(Vector3.right);
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Salto");
            PlayerCC.Move(Vector3.up * 8f * Time.deltaTime); ;
        }

        Gravity();
       
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
        bool jump = Input.GetKeyDown(KeyCode.Space);

        if (forward) playerAnimator.SetTrigger("Run");
        if (back) playerAnimator.SetTrigger("RunBack");
        if (left) playerAnimator.SetTrigger("RunLeft");
        if (right) playerAnimator.SetTrigger("RunRight");
        if (jump) playerAnimator.SetTrigger("JumpUp");

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.Space))
        {
            if (!IsAnimation("Idle")) playerAnimator.SetTrigger("Idle");
        }
    }

    void Gravity()
    {
        if (PlayerCC.isGrounded) playerDirection.y = 0f;

        playerDirection.y += -9.81f * Time.deltaTime;
        PlayerCC.Move(playerDirection * Time.deltaTime);
    }
}
