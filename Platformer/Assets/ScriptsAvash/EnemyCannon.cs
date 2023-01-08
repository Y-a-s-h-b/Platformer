using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class EnemyCannon : MonoBehaviour
{
    public Transform playerGun;
    private Vector3 direction;
    private Rigidbody2D rb;
    public GameObject firePoint;
    public GameObject cannonBulletPrefab;
    public float bulletSpawnTime;
    private float bulletTimer=0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction =  transform.position - playerGun.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        rb.rotation = angle;

        bulletTimer += Time.deltaTime;
        
        if ((playerGun.position - transform.position).magnitude<10 && bulletTimer>bulletSpawnTime)
        {
            fire();
            bulletTimer = 0f;
        }
    }

    private void fire()
    {
        Instantiate(cannonBulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        
    }

    
}
