using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    public void LoadCutscene()
    {
        SceneManager.LoadScene(1);
    }
   public void LoadLvlOne()
    {
        SceneManager.LoadScene(2);
    }

    // For GameOver Menu
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
