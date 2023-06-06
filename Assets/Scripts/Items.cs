using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
    if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.playerHealth += 2;
            Destroy(gameObject);
        }    
    }
}
