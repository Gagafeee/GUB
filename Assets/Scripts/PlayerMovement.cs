using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public float moveSpeed;
    public float climbSpeed;
    public float jumpForce;

    public Vector3 pos;

    private bool isJumping;
    private bool isGrounded;
    [HideInInspector]
    public bool isClimbing;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D playerCollider;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;
    public GameObject Player;

    public static PlayerMovement instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;


    }

    public void PositionPlayer()
    {
        if (CurrentSceneManager.instance.isTheFirstEnterInLevel == false)
        {
            Player.GetComponent<Transform>().position = CurrentSceneManager.instance.RespawnPoint;
        }
        
    }

    void Update()
    {
        if (PlayerHealth.instance.isDie == false)
        {
            pos.x = Player.GetComponent<Transform>().position.x;
            pos.y = Player.GetComponent<Transform>().position.y;
            pos.z = Player.GetComponent<Transform>().position.z;

            if (Input.GetKeyDown(KeyCode.Y))
            {
                Player.GetComponent<Transform>().position = CurrentSceneManager.instance.RespawnPoint;
            }

            horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
            verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;

            if (Input.GetButtonDown("Jump") && isGrounded && !isClimbing)
            {
                Statistic.Instance.jumps++;
                isJumping = true;
            }

            if (isJumping)
            {
                animator.SetBool("isJump", isJumping);
            }
            /*   if(!isJumping)
               {
                   animator.SetBool("isJump", isJumping);
               }*/
            if (isGrounded)
            {
                animator.SetBool("isGround", isGrounded);
            }
            if (!isGrounded)
            {
                animator.SetBool("isGround", isGrounded);
            }

            Flip(rb.velocity.x);

            float characterVelocity = Mathf.Abs(rb.velocity.x);
            animator.SetFloat("Speed", characterVelocity);
            animator.SetBool("isClimbing", isClimbing);
            if (characterVelocity >= 1.5 || isJumping)
            {
                Inventory.inventory.CloseInventory();
            }
            
     
        }

    }

    void FixedUpdate()
    {
        if (PlayerHealth.instance.isDie == false)
        {

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
            MovePlayer(horizontalMovement, verticalMovement);
        }
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        if (PlayerHealth.instance.isDie == false)
        {
            if (!isClimbing)
            {
                Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
                rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

                if (isJumping)
                {
                    rb.AddForce(new Vector2(0f, jumpForce));
                    isJumping = false;
                }
            }
            else
            {
                Vector3 targetVelocity = new Vector2(0, _verticalMovement);
                rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
            }
        }


    }

    void Flip(float _velocity)
    {
        if (PlayerHealth.instance.isDie == false)
        {
        }
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
