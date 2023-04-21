using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartAfterDelay : MonoBehaviour
{
void Start()
{
    Invoke("AppearUFOBoss", 10f);
}

void AppearUFOBoss()
{
    gameObject.SetActive(true);
}
}
