using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text coinText;
    private int coin = 0;
    [SerializeField] private AudioSource collect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collect.Play();
            Destroy(collision.gameObject);
            coin++;
            coinText.text = "Coin: " + coin;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
