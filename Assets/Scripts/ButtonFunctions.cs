using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public void ExitGame()
    {
        GameManager.instance.ExitGame();
    }

    public void LoadScene(string sceneName)
    {
        GameManager.instance.LoadScene(sceneName);
    }
}
