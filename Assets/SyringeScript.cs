using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeScript : MonoBehaviour
{
    [SerializeField] GameObject syringeOne;
    [SerializeField] GameObject syringeTwo;
    [SerializeField] GameObject syringeThree;


    void Update()
    {
        if (GameManager.Instance.items[0] == null)
        {
            syringeOne.SetActive(false);
        }
        else
        {
            syringeOne.SetActive(true);
        }
        if (GameManager.Instance.items[1] == null)
        {
            syringeTwo.SetActive(false);
        }
        else
        {
            syringeTwo.SetActive(true);
        }
        if (GameManager.Instance.items[2] == null)
        {
            syringeThree.SetActive(false);
        }
        else
        {
            syringeTwo.SetActive(true);
        }
    }
}
