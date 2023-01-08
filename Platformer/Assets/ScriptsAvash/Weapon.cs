using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    [SerializeField]private float gunRotation = 10f;
    private float gunRotationZ;
    private Rigidbody2D gunrb;    
    [SerializeField]private float recoil = 2f;
    public Transform playerCharacter;
    public Rigidbody2D playerRb;
    [SerializeField]private float maxSpeed;
    [SerializeField]private int bulletCapacity;
    public GameObject BulletText;

    // Start is called before the first frame update
    void Start()
    {
        gunRotationZ = transform.rotation.z;
        gunrb = this.GetComponent<Rigidbody2D>();
        BulletText.GetComponent<Text>().text = "20";
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerRb.velocity.magnitude>maxSpeed)
        {
            playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, maxSpeed);
        }

        this.transform.position = playerCharacter.position;
        if (Input.GetButtonDown("Fire1") && bulletCapacity>0)
        {
            fire();
        }

        if (Input.GetKey(KeyCode.A))
        {
            gunRotationZ += gunRotation;
            //Debug.Log(transform.rotation.z);
            transform.rotation = Quaternion.Euler(0f,0f,gunRotationZ);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gunRotationZ -= gunRotation;
            
            transform.rotation = Quaternion.Euler(0f, 0f, gunRotationZ);
        }
                
    }

    private void fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        playerRb.AddForce(-transform.right*recoil, ForceMode2D.Impulse);
        bulletCapacity--;

        bulletChangingText();
    }

    public void bulletChangingText()
    {
        BulletText.GetComponent<Text>().text = bulletCapacity.ToString();
        Debug.Log("bulletchanged");
    }

    
}
