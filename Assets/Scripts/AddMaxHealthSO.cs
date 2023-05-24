using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreateMaxHealthItem", menuName = "New Add More Max Health Item")]

public class AddMaxHealthSO : ScriptableObject
{
    public int maxHealthAdded;

    public void WhenCollected()
    {
        GameManager.Instance.maxHealth += maxHealthAdded;
    }
}
