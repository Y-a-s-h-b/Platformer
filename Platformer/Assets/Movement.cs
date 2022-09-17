using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX;
    private SpriteRenderer sprite;
    private Animator anim;
    public float moveSpeed;
    public float jumpForce;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*moveSpeed,rb.velocity.y);
        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce) ;
            
        }
        UpdateAnimationUpdate();
        void UpdateAnimationUpdate()
        {
            if(dirX > 0f){
                anim.SetBool("Run",true);
                sprite.flipX = false;
        }
            else if(dirX < 0f){
                anim.SetBool("Run",true);
                sprite.flipX = true;
        }
            else{
                anim.SetBool("Run",false);
        }
        }

    }
    
}
