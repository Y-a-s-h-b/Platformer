using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPosition : MonoBehaviour
{
    public Transform gun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = gun.position;
    }
}
