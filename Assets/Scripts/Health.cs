using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum healthObject { enemy, player }
public class Health : MonoBehaviour
{
    public healthObject healthType;
    public GameObject accessibleObject;
    public float health;
    void Update() {
        if (healthType == healthObject.player) {
            Slider slider = accessibleObject.GetComponent<Slider>();
            slider.value = health / 10;
        }
    }
    public void UpdateHealth(float amount) {
        health += amount;
    }

}
