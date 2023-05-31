using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCustcene : MonoBehaviour
{
    public Animator CameraAnimator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraAnimator.SetBool("cutscene1", true);
        }
    }
}
