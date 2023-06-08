using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackhitbox : MonoBehaviour
{
    //this script will be on the enemy
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("attack hitbox"))
        {
            Destroy(gameObject);
        }
    }
}
