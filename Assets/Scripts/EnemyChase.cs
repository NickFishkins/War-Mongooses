using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float ChaseSpeed = 1f;
    public Transform target;
    public float withinRange;

    public void Update()
    {
        //Gets the distance between the player and enemy
        float dist = Vector2.Distance(target.position, transform.position);
        // Checking if the distance of the enemy is within the range
        if (dist <= withinRange)
        {
            //Move to the player 
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, ChaseSpeed);
        }
    }
}
