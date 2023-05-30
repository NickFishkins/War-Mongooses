using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Aggression { Aggressive, Medium, Passive }
public class EnemyAI : MonoBehaviour
{
    public Aggression aggresiveness;
    public bool randomAggression = false;

    public GameObject player;
    private float dist;
    private Vector2 towardLoc;

    private float chaseRange = 7;
    private float releaseRange = 15;
    private float investigateRange = 20;
    private bool isChase = false;

    private Rigidbody2D body;

    public float chaseSpeed = 5;
    public float slowSpeed = 3;
    private float usingSpeed = 5;
    private float speed = 5;
    private float veloc = 0;
    private float smoothTime = 0.5f;

    private Vector2 loc;
    private bool wait = false;

    private float negator = 1;
    private Vector2 origin;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        if (randomAggression)
        {
            float rand = Random.Range(0, 2);
            switch (rand)
            {
                case 0: aggresiveness = Aggression.Aggressive; break;
                case 1: aggresiveness = Aggression.Medium; break;
                case 2: aggresiveness = Aggression.Passive; break;
            }
        }
        switch (aggresiveness)
        {
            case Aggression.Aggressive:
                chaseRange = 7;
                releaseRange = 15;
                investigateRange = 16;
                chaseSpeed = 6;
                slowSpeed = 5;
                break;
            case Aggression.Medium:
                chaseRange = 7;
                releaseRange = 10;
                investigateRange = 11;
                chaseSpeed = 5;
                slowSpeed = 3;
                break;
            case Aggression.Passive:
                chaseRange = 6;
                releaseRange = 9;
                investigateRange = 10;
                chaseSpeed = 4;
                slowSpeed = 2;
                break;
        }
        origin = transform.position;
    }
    void Update()
    {
        towardLoc = loc - new Vector2(transform.position.x, transform.position.y);
        dist = Vector2.Distance(transform.position, player.transform.position);

        // Chase
        if (dist < chaseRange)
        {
            isChase = true;
        }
        if (dist > releaseRange)
        {
            isChase = false;
        }
        if (isChase)
        {
            ChasePlayer();
        }

        // Patrol
        if (dist > investigateRange && !isChase)
        {
            Patrol();
        }

        // Investigate
        if (dist < investigateRange && !isChase)
        {
            Investigate();
        }

        // Move to loc
        body.transform.Translate(new Vector2(speed * towardLoc.normalized.x, 0) * Time.deltaTime);
        if (body.transform.position.x < loc.x - 0.1f || body.transform.position.x > loc.x + 0.1f)
        {
            speed = Mathf.SmoothDamp(speed, usingSpeed, ref veloc, smoothTime);
        }
        else
        {
            speed = Mathf.SmoothDamp(speed, 0, ref veloc, smoothTime);
        }
    }
    void ChasePlayer()
    {
        Debug.Log("Chase");
        loc = player.transform.position;
        usingSpeed = chaseSpeed;
    }
    void Patrol()
    {
        Debug.Log("Patrol");
        usingSpeed = slowSpeed;
        if (!wait)
        {
            negator *= -1f;
            loc = new Vector2(Random.Range(5, 10f) * negator + origin.x, 0);
            wait = true;
            StartCoroutine(Timer(6));
        }
    }
    void Investigate()
    {
        Debug.Log("Investigate");
        usingSpeed = slowSpeed;
        loc = player.transform.position;
    }
    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        wait = false;
    }
}