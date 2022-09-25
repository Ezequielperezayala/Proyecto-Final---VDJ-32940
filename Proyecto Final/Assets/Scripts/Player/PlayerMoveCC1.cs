using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCC1 : MonoBehaviour
{
    //variables de inputs
    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 playerMove;
    public float fallVelocity;
   
    

    //variables serializadas
    [SerializeField] CharacterController player;
    [SerializeField][Range(0,10)] float playerSpeed;
    [SerializeField] Camera mainCamera;
    [SerializeField][Range(0, 10)] float gravity;
    [SerializeField][Range(0, 10)] float jumpForce;

    //variables de animacion
    [SerializeField] Animator playerAnimatorController;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        playerAnimatorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()//metodo para el movimiento
    {
        //tomo los axis verticales y horizontales
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        //cancelo la aceleracion en diagonal 
        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        playerAnimatorController.SetFloat("forwardVelocity", playerInput.magnitude * playerSpeed);
        //movimiento con respecto a la camara
        CamDirection();
        playerMove = playerInput.x * camRight + playerInput.z * camForward;
        player.transform.LookAt(player.transform.position + playerMove);
        //aplico gravedad
        SetGravity();
        //aplico salto
        PlayerSkills();
        //muevo el player
        playerMove *= playerSpeed;
        player.Move(playerMove * Time.deltaTime);
        
    }

    void CamDirection()//Metodo que almacena la posicion de la camara
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;

    }

    void SetGravity()//metodo que aplica gravedad
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            playerMove.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            playerMove.y = fallVelocity;
            playerAnimatorController.SetFloat("verticalVelocity", player.velocity.y);
        }

        playerAnimatorController.SetBool("isGrounded", player.isGrounded) ;
    }

    void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            playerMove.y = fallVelocity;
            playerAnimatorController.SetTrigger("playerJump");
        }
    }

    private void OnAnimatorMove()
    {
        
    }



}
