using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private float dirX;
    private SpriteRenderer sprite;
    private Animator anim;
    public float moveSpeed;
    public float jumpForce;
    public LayerMask jumpableGround;
    private enum MovementState { Idle,Run,Jump,Fall,DoubleJump,Hit}
    [SerializeField] private AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*moveSpeed,rb.velocity.y);
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            
        }
        UpdateAnimationUpdate();
        void UpdateAnimationUpdate()
        {
            MovementState state;
            if(dirX > 0f){
                sprite.flipX = false;
                state = MovementState.Run;
            }
            else if(dirX < 0f){
                state = MovementState.Run;
                sprite.flipX = true;
        }
            else{
                state = MovementState.Idle;
            }
            if(rb.velocity.y > .1f)
            {
                state = MovementState.Jump;
            }
            else if(rb.velocity.y < -.1f)
            {
                state = MovementState.Fall;
            }
            anim.SetInteger("state", (int)state);
        }
        bool IsGrounded()
        {
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        }

    }
    
}
