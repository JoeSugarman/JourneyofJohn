using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    [Header("Movement parameter")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime; //how much time the player can jump after falling off the platform
    private float coyoteCounter;//how much time passed since the player fell off the platform

    [Header("multiple Jumps")]
    [SerializeField] private int extraJumps;
    private int jumpCounter;

    [Header("Wall Jumping")]
    [SerializeField] private float wallJumpX; //how much force to apply on x axis when wall jumping
    [SerializeField] private float wallJumpY; //how much force to apply on y axis when wall jumping

    [Header("ground layer")]
    [SerializeField]  private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    

    [Header ("SFX")]
    [SerializeField] private AudioClip jumpSound;

    private Rigidbody2D body;
    private float wallJumpCooldown;
    private float horizontalInput;
    private Animator anim;
    private BoxCollider2D boxCollider;

    //trail renderer
    private TrailRenderer trailRenderer;
    private Rigidbody2D rb;
    PlayerAction controls;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        controls = new PlayerAction();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.enabled = false;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //flip the player for left or right movement
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }else if (horizontalInput < -0.01f)
        {
           transform.localScale = new Vector3(-1, 1, 1);
        }

        
        //set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        ////wall jump logic
        //if (wallJumpCooldown > 0.2f) {


        //    body.velocity = new Vector2(horizontalInput*speed, body.velocity.y);

        //    if(onWall() && !isGrounded())
        //    {
        //        body.gravityScale = 0;
        //        body.velocity = Vector2.zero;
        //    }
        //    else
        //    {
        //        body.gravityScale = 2.5f;
        //    }


        //    if (Input.GetKey(KeyCode.Space))
        //    {
        //        Jump();

        //        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        //        {
        //            SoundManager.instance.PlaySound(jumpSound);
        //        }
        //    }

        //}
        //else
        //{

        //   wallJumpCooldown += Time.deltaTime;
        //}

        //jump
        if (//Input.GetKeyDown(KeyCode.Space)

            Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.JoystickButton0)//|| Input.GetButtonDown("Jump")
            )
        {
            Jump();
        }

        //adjustable jump height
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);
        }

        //check if player on wall
        if (onWall())
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
        }
        else
        {
            body.gravityScale = 7;
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (isGrounded())
            {
                coyoteCounter = coyoteTime; //reset the coyote counter
                jumpCounter = extraJumps; //reset the jump counter
                trailRenderer.enabled = false;
            }
            else
            {
                coyoteCounter -= Time.deltaTime; //start counting down the coyote counter
                trailRenderer.enabled = true;
            }
        }

    }
    private void Jump()
    {
        if (coyoteCounter < 0 && !onWall() && jumpCounter<=0) return; //if coyote counter is less than 0, dont do anything

        SoundManager.instance.PlaySound(jumpSound);

        if (onWall())
            WallJump();
        else
        {
            if (isGrounded())
                body.velocity = new Vector2(body.velocity.x, jumpPower);
            else
            {
                //If not on the ground and coyote counter is greater than 0, jump
                if (coyoteCounter>0)
                    body.velocity = new Vector2(body.velocity.x, jumpPower);
                else
                {
                    if (jumpCounter > 0) //if we have extra jumps
                    {
                        body.velocity = new Vector2(body.velocity.x, jumpPower);
                        jumpCounter--;
                    }
                }
            }
            //reset counter to avoid double jump
            coyoteCounter = 0;
        }
        //if (isGrounded())
        //{
        //    //SoundManager.instance.PlaySound(jumpSound);
        //    body.velocity = new Vector2(body.velocity.x, jumpPower);
            
        //    //anim.SetTrigger("jump");
        //}
        //else if (onWall()&&!isGrounded())
        //{
        //    if(horizontalInput == 0)
        //    {
        //        body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
        //        transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        //    }
        //    else
        //    {
        //        body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
        //    }
        //    wallJumpCooldown = 0;
           
        //}


    }

    private void WallJump()
    {
        body.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpX, wallJumpY)); //add force to the player
        wallJumpCooldown = 0;
    }


    private bool isGrounded() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;

    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }

}
