using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadScene(int SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
