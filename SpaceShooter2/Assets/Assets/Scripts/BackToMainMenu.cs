using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToMainMenu : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene("MainMenu2");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void Scene3()
    {
        SceneManager.LoadScene("Scene3");
    }
}