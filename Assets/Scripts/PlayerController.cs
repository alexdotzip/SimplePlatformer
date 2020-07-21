using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private CapsuleCollider2D myCollider;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;
    private Animator anim;
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        myRigidbody.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), myRigidbody.velocity.y );


        //Basic Sprinting
        if (Input.GetButtonDown("Fire3"))
        {
            moveSpeed += 4f;
        } else if (Input.GetButtonUp("Fire3"))
        {
            moveSpeed -= 4f;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        if(isGrounded)
        {
            canDoubleJump = true;
        }

        //Basic Jumping
        if(Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
            else
            {
                if(canDoubleJump)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }

        if(myRigidbody.velocity.x < 0)
        {
            mySpriteRenderer.flipX = true;
        } else if(myRigidbody.velocity.x > 0)
        {
            mySpriteRenderer.flipX = false;
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(myRigidbody.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

    }
}
