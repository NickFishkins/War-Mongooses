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
            Invoke(nameof(StopCutscene), 3f);
        }
    }

    void StopCutscene()
    {
        CameraAnimator.SetBool("cutscene1", false);
    }
}
