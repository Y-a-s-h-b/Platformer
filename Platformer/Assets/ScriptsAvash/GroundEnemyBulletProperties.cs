using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyBulletProperties : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        StartCoroutine(destroy());
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
