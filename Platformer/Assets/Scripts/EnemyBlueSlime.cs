using UnityEngine;

public class EnemyBlueSlime : MonoBehaviour
{
    [Header("For Enemy Movement")]
    [SerializeField] private float moveSpeed;
    private float moveDirection = 1;
    private bool facingRight = true;
    public float rayDistance = 1.0f;
    public float circleRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    private bool checkingGround;
    [Header("Others")]
    private Rigidbody2D enemyRB;
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        checkingGround = Physics2D.OverlapCircle(groundCheck.position, circleRadius, groundLayer);
        isMoving();
    }
        
        
        /*if (playerPos.position.x < gameObject.transform.position.x) {
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
    else
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }
 */
    void isMoving()
        {
            if (!checkingGround )
            {
                if (facingRight)
                {
                    flip();
                }
                else if (!facingRight)
                {
                    flip();
                }
            }
        enemyRB.velocity = new Vector2(moveSpeed * moveDirection, enemyRB.velocity.y);
    }
        void flip()
        {
        moveDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180,0);
        }
}
