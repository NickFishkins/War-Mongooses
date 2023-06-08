using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public int health;
    public Slider slider;


    void Update() 
    {
        health = GameManager.Instance.playerHealth;
        UpdateTheHP();
    }

    void UpdateTheHP()
    {
        slider.value = health;
    }
  
}
