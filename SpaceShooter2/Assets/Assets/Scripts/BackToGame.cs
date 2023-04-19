using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToGame : MonoBehaviour
{
    public PauseScript pauseScript;

    public void OnButtonClick()
    {
        pauseScript.ContinueGame();
    }
}