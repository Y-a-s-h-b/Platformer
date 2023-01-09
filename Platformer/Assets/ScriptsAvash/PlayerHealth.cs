using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth<=0)
        {
            //game end or respawn
        }
    }
}
