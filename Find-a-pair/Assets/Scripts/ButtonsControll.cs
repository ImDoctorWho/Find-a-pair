using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsControll : MonoBehaviour
{
    public void StartGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGameScene()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
