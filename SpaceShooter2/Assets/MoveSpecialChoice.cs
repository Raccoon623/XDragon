using UnityEngine;
using UnityEngine.UI;

public class MoveSpecialChoice : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    public Button toggleButton;

    private void Start()
    {
        toggleButton.onClick.AddListener(ToggleObjectsState);
    }

    private void ToggleObjectsState()
    {
        if (objectA != null)
            objectA.SetActive(true);

        if (objectB != null)
            objectB.SetActive(false);
    }
}