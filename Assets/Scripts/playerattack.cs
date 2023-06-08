using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    //this script will be on the player instantiating the prefab
    [SerializeField] GameObject attackhitbox;
    private GameObject enemykiller;
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            enemykiller = Instantiate(attackhitbox) as GameObject;
            enemykiller.transform.position = player.transform.position;
            Invoke(nameof(yourmother), 1f);
        }
    }
    void yourmother()
    {
        GameObject.Destroy(enemykiller);
    }
}
