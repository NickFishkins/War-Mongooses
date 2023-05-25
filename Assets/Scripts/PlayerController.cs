using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Starts by setting the players health to the cap.
        GameManager.Instance.maxHealth = 10;
        GameManager.Instance.playerHealth = GameManager.Instance.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Gives the player a health cap.
        if(GameManager.Instance.playerHealth >= GameManager.Instance.maxHealth)
        {
            GameManager.Instance.playerHealth = GameManager.Instance.maxHealth;
        }
    }
}
