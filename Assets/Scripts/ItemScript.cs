using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            GameManager.Instance.items.Add(gameObject);
            _collider.enabled = false;
        }
    }
}
