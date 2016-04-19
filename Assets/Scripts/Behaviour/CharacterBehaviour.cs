using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(MovementBehaviour))]
public class CharacterBehaviour : MonoBehaviour 
{
    public MovementBehaviour movementBehaviour { set; get; }
    public InputController inputController { set; get; }

    public float velocity;                  // Speed to the player movie

    private Transform groundCheck;			// A position marking where to check if the player is grounded.
    private bool grounded = false;			// Whether or not the player is grounded.
    private bool isJump = true;             // Set a player is moment to jump

    void Awake()
    {
        // Setting up references.
        this.groundCheck = transform.Find("groundCheck");
        this.movementBehaviour = GetComponent<MovementBehaviour>();
        this.inputController = GameObject.Find("MyControl").GetComponent<InputController>();
    }

    void OnEnable()
    {
        //Input Controller (Attack, Jump and other)
        this.inputController.ev_rightControl_down += HandleRightDown;
        this.inputController.ev_rightControl_left += HandleRightLeft;
        this.inputController.ev_rightControl_right += HandleRightRight;
        //Input directional (Movement)
        this.inputController.ev_leftControl_down += HandleDown;
        this.inputController.ev_leftControl_up += HandleUp;
        this.inputController.ev_leftControl_left += HandleLeft;
        this.inputController.ev_leftControl_right += HandleRight;

        //Input Up
        this.inputController.ev_last_frame += HandleLast;

    }

    void OnDisable()
    {
        //Input Controller (Attack, Jump and other)
        this.inputController.ev_rightControl_down -= HandleRightDown;
        this.inputController.ev_rightControl_left -= HandleRightLeft;
        this.inputController.ev_rightControl_right -= HandleRightRight;
        //Input directional (Movement)
        this.inputController.ev_leftControl_down -= HandleDown;
        this.inputController.ev_leftControl_up -= HandleUp;
        this.inputController.ev_leftControl_left -= HandleLeft;
        this.inputController.ev_leftControl_right -= HandleRight;

        //Input Up
        this.inputController.ev_last_frame -= HandleLast;
    }

    void Update()
    {
        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        this.grounded = Physics2D.Linecast(gameObject.transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        Debug.Log(this.grounded);
        
        if (this.grounded)
        {
            this.isJump = true;
        }
    }

    /// <summary>
    /// Metodo do ultimo frame
    /// </summary>
    void HandleLast()
    {
        this.movementBehaviour.stop();
    }

    /// <summary>
    /// Método responsavel pela ação baixo (SETOR/ESCOLHA)
    /// </summary>
    void HandleRightDown() 
    {
        if (this.isJump)
        {
            this.movementBehaviour.jump();
            this.isJump = false;
        }
    }
    /// <summary>
    /// Método responsavel pela ação esquerda (SETOR/ESCOLHA)
    /// </summary>
    void HandleRightLeft() 
    {
        print("Atacou");
    }
    /// <summary>
    /// Método responsavel pela ação direita (SETOR/ESCOLHA)
    /// </summary>
    void HandleRightRight() 
    {
        print("Esquivou");
    }
    /// <summary>
    /// Método responsavel pela ação baixo (MOVIMENTAÇÃO)
    /// </summary>
    void HandleDown() 
    {
        print("Baixo");
    }
    /// <summary>
    /// Método responsavel pela ação cima (MOVIMENTAÇÃO)
    /// </summary>
    void HandleUp() 
    {
        print("Pra cima");
    }
    /// <summary>
    /// Método responsavel pela ação esquerda (MOVIMENTAÇÃO)
    /// </summary>
    void HandleLeft()
    {
        this.movementBehaviour.move(new Vector2(-this.velocity, this.movementBehaviour.rigidbody2D.velocity.y));
    }
    /// <summary>
    /// Método responsavel pela ação direita (MOVIMENTAÇÃO)
    /// </summary>
    void HandleRight() 
    {
        this.movementBehaviour.move(new Vector2(this.velocity, this.movementBehaviour.rigidbody2D.velocity.y));
    }
}
