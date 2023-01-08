using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine(destroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    } 
}
