using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreateAddHealthItem", menuName = "New Add Health Item")]

public class AddHealthSO : ScriptableObject
{
    public int healthAdded;

    public void WhenCollected()
    {
        // Do something to put it in the inventory
    }
}
