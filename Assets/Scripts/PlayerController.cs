using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.maxHealth = 5;
        GameManager.Instance.playerHealth = GameManager.Instance.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
