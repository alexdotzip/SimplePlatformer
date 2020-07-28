using UnityEngine;


public enum PlayerState
{
    idle,
    walking,
    sprinting,
    jumping,
}
public class PlayerController : MonoBehaviour
{


    public static PlayerController instance;

    public PlayerState currentState;

    [Header("Properties ")]
    public float moveSpeed;
    public float jumpForce;
    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private CapsuleCollider2D myCollider;
    [SerializeField] private float bounceForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    [Header("Animations")]
    private Animator anim;
    private SpriteRenderer mySpriteRenderer;

    [Header("Knockback Data")]
    public float knockbackLength;
    public float  knockbackForce;
    private float knockbackCounter;

    

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        currentState = PlayerState.idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.instance.isPaused)
        {
            if (knockbackCounter <= 0)
            {

                //  SprintCheck();

                myRigidbody.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), myRigidbody.velocity.y);


                JumpCheck();

                if (myRigidbody.velocity.x < 0)
                {
                    mySpriteRenderer.flipX = true;
                }
                else if (myRigidbody.velocity.x > 0)
                {
                    mySpriteRenderer.flipX = false;
                }
            }
            else
            {
                knockbackCounter -= Time.deltaTime;
                if (!mySpriteRenderer.flipX)
                {
                    myRigidbody.velocity = new Vector2(-knockbackForce, myRigidbody.velocity.y);
                }
                else
                {
                    myRigidbody.velocity = new Vector2(knockbackForce, myRigidbody.velocity.y);
                }
            }

        }
        anim.SetFloat("moveSpeed", Mathf.Abs(myRigidbody.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

    }

    private void JumpCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        if (isGrounded)
        {
            canDoubleJump = true;
        }

        //Basic Jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                AudioManager.instance.PlaySFX(0);
            }
            else
            {
                if (canDoubleJump)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                    AudioManager.instance.PlaySFX(0);
                    canDoubleJump = false;
                }
            }
        }
    }

    //private void SprintCheck()
    //{


    //    //Basic Sprinting
    //    if (Input.GetButtonDown("Fire3"))
    //    {
    //        anim.SetBool("isSprinting", true);
    //        moveSpeed += 4f;
    //    }
    //    else if (Input.GetButtonUp("Fire3"))
    //    {
    //        anim.SetBool("isSprinting", false);
    //        moveSpeed -= 4f;
    //    } 
    //}

    public void Knockback()
    {
        knockbackCounter = knockbackLength;
        myRigidbody.velocity = new Vector2(0f, knockbackForce);
        AudioManager.instance.PlaySFX(3);
        anim.SetTrigger("hurt");
    }

    public void Bounce()
    {
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, bounceForce);
    }
}
