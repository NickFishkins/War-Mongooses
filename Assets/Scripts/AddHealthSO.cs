using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreateAddHealth", menuName = "New Add Health")]

public class AddHealthSO : ScriptableObject
{
    public int healthAdded;

    public void WhenCollected()
    {
        GameManager.Instance.playerHealth += healthAdded;
    }
}
