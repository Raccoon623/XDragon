using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSpecial : MonoBehaviour

{
    public GameObject objectToMove;
    public Button specialButton;
    public Button backButton;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = objectToMove.transform.position;
        specialButton.onClick.AddListener(MoveObjectToNewLocation);
        backButton.onClick.AddListener(MoveObjectToOriginalLocation);
    }

    void MoveObjectToNewLocation()
    {
        Vector3 newPosition = new Vector3(580, objectToMove.transform.position.y, objectToMove.transform.position.z);
        objectToMove.transform.position = newPosition;
    }

    void MoveObjectToOriginalLocation()
    {
        objectToMove.transform.position = originalPosition;
    }
}
