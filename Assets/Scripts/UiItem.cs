using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiItem : MonoBehaviour
{
    public ItemScript syringe;
    private Image _sprite;

    void Awake()
    {
        _sprite = GetComponent<Image>();
        UpdateItems(null);
    }

    
    void UpdateItems(ItemScript syringe)
    {
        this.syringe = syringe;
        if(this.syringe = null)
        {
            _sprite.color = Color.clear;
        }
        else
        {
            _sprite.color = Color.white;
            _sprite.sprite = this.syringe.icon;
        }
    }
}
