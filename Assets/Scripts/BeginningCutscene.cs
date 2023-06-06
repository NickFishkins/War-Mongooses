using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginningCutscene : MonoBehaviour
{
    public Animator beginningCutscene;
    // Start is called before the first frame update
    void Start()
    {
        beginningCutscene.SetBool("Camera1", true);
        Invoke(nameof(Camera2), 3f);
    }
    void Camera2()
    {
        beginningCutscene.SetBool("Camera2", true);
        beginningCutscene.SetBool("Camera1", false);
        Invoke(nameof(Camera3), 3f);
    }
    void Camera3()
    {
        beginningCutscene.SetBool("Camera2", false);
        beginningCutscene.SetBool("Camera3", true);
        Invoke(nameof(Camera4), 3f);
    }
    void Camera4()
    {
        beginningCutscene.SetBool("Camera3", false);
        beginningCutscene.SetBool("Camera4", true);
        Invoke(nameof(Camera5), 3f);
    }
    void Camera5()
    {
        beginningCutscene.SetBool("Camera4", false);
        beginningCutscene.SetBool("Camera5", true);
        Invoke(nameof(Camera6), 3f);
    }
    void Camera6()
    {
        beginningCutscene.SetBool("Camera5", false);
        beginningCutscene.SetBool("Camera6", true);
        Invoke(nameof(Camera7), 3f);
    }
    void Camera7()
    {
        beginningCutscene.SetBool("Camera6", false);
        beginningCutscene.SetBool("Camera7", true);
        Invoke(nameof(Camera8), 3f);
    }
    void Camera8()
    {
        beginningCutscene.SetBool("Camera7", false);
        beginningCutscene.SetBool("Camera8", true);
        Invoke(nameof(Camera9), 3f);
    }
    void Camera9()
    {
        beginningCutscene.SetBool("Camera8", false);
        beginningCutscene.SetBool("Camera9", true);
        Invoke(nameof(Camera10), 3f);
    }
    void Camera10()
    {
        beginningCutscene.SetBool("Camera9", false);
        beginningCutscene.SetBool("Camera10", true);
        Invoke(nameof(Camera11), 3f);
    }
    void Camera11()
    {
        beginningCutscene.SetBool("Camera10", false);
        beginningCutscene.SetBool("Camera11", true);
        Invoke(nameof(Camera12), 3f);
    }
    void Camera12()
    {
        beginningCutscene.SetBool("Camera11", false);
        beginningCutscene.SetBool("Camera12", true);
        Invoke(nameof(Camera13), 3f);
    }
    void Camera13()
    {
        beginningCutscene.SetBool("Camera12", false);
        beginningCutscene.SetBool("Camera13", true);
        Invoke(nameof(Camera14), 3f);
    }
    void Camera14()
    {
        beginningCutscene.SetBool("Camera13", false);
        beginningCutscene.SetBool("Camera14", true);
        Invoke(nameof(Camera15), 3f);
    }
    void Camera15()
    {
        beginningCutscene.SetBool("Camera14", false);
        beginningCutscene.SetBool("Camera15", true);
        Invoke(nameof(SceneChange), 3f);
    }
    void SceneChange()
    {
        SceneManager.LoadScene(2);
    }
}
