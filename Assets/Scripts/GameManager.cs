using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int playerHealth;
    public int maxHealth;

    public List<GameObject> items = new List<GameObject>();
    public int itemEquipped;

    // Awake is the first method callled, even before start
    private void Awake()
    {
        // Checks if there is another singleton in the scene and if there isnt it 
        // sets the singleton to the current singleton. If there is it destroys itself.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}