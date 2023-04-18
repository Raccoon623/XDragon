using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DisableFire : MonoBehaviour
{
    public FireKey fireKeyScript;
    private bool isFireKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFireKeyPressed = !isFireKeyPressed;
        }

        if (isFireKeyPressed)
        {
            fireKeyScript.enabled = true;
        }
        else
        {
            fireKeyScript.enabled = false;
        }
    }
}

public class ToggleWeapon : MonoBehaviour
{
    public GameObject weapon;
    private bool isSpacebarPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpacebarPressed = !isSpacebarPressed;
            weapon.SetActive(isSpacebarPressed);
        }
    }
}



