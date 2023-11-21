using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Character character;
    public InputAction move;
    public InputAction turn;
    public InputActionAsset inputAsset;
    public InputActionMap player;
    public bool Player1 = false;
    public GameObject ShootSound;


    private Rigidbody rb;
    [SerializeField]
    private float movementForce = 1.0f;
    [SerializeField]
    private float jumpForce = 5.0f;
    [SerializeField]
    private float maxSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;

    [SerializeField]
    public Camera playerCamera;

    private static PlayerController _instance;

    public static PlayerController Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
       _instance = this;  
        rb = this.GetComponent<Rigidbody>();
        character = new Character();
        inputAsset = this.GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Player");
        ShootSound = GameObject.FindGameObjectWithTag("GunShot");
    }

    private void OnEnable()
    {
      /*  character.Player.Jump.started += DoJump;
        character.Player.Shoot.started += DoShoot;
        move = character.Player.Move;
        turn = character.Player.Look;
        character.Player.Enable();*/

        player.FindAction("Jump").started += DoJump;
        player.FindAction("Shoot").started += DoShoot;
        move = player.FindAction("Move");
        turn = player.FindAction("Look");
        player.Enable();
    }

   

    private void OnDisable()
    {
        player.FindAction("Jump").started += DoJump;
        player.FindAction("Shoot").started += DoShoot;
        player.Disable();
    }

   

    private void FixedUpdate()
    {
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera)* movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;
        
        rb.AddForce(forceDirection,ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if (rb.velocity.y < 0f)
        {
            rb.velocity += Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        }

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0f;
        if (horizontalVelocity.sqrMagnitude > maxSpeed*maxSpeed)
        {
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;
        }

        LookAt();
    }

    public Vector2 getTurn()
    {
        return (player.FindAction("Look")).ReadValue<Vector2>();
    }
   
    private void LookAt()
    {
        Vector3 Direction = rb.velocity;
        Direction.y = 0f;

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && Direction.sqrMagnitude > 0.1f)
        {
            this.rb.rotation = Quaternion.LookRotation(Direction, Vector3.up);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }
    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 Forward = playerCamera.transform.forward;
        Forward.y = 0;
        return Forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 Right = playerCamera.transform.right;
        Right.y = 0;
        return Right.normalized;
    }

    private void DoJump(InputAction.CallbackContext context)
    {
        if (isGrounded())
        {
            forceDirection += Vector3.up * jumpForce;
           
        }
    }

    private void DoShoot(InputAction.CallbackContext context)
    {
        RaycastHit Hit;
        ShootSound.SetActive(true);
        Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out Hit);
        Debug.Log(Hit.transform.name);
        if (Hit.transform.name == "Soldier Rigged")
        {
            Hit.transform.GetComponent<PlayerController>().TakeDamage();
        }
    }

    private bool isGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray,out RaycastHit hit,0.03f))
        {
            return true;
        }
        else 
        { 
            return false; 
        }
            
      
    }

    public void TakeDamage()
    {
        if (Player1)
        {
            Game_Manager.Player2HP--;
        }
        else
        {
            Game_Manager.Player1HP--;
        }
    }


}
