using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPlay : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("TestScene");
    }
}
