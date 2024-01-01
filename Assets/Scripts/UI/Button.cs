using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    public void ToInGameScene()
    {
        SceneManager.LoadScene("InGame");
        Time.timeScale = 1.0f;
    }

    public void ToStartScene()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        transform.parent.gameObject.SetActive(false);
    }

    public void ReStartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("InGame");
    }
}
