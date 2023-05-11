using UnityEngine;
using UnityEngine.UI;

public class CreditsRoll : MonoBehaviour
{
    public float speed = 1f; // speed of movement
    public Text text1; // first Text object to move
    public Text text2; // second Text object to move
    public Text text3; // third Text object to move
    public Text text4; // first Text object to move
    public Text text5; // second Text object to move
    public Text text6; // third Text object to move


    private void Update()
    {
        // move each Text object negatively in the Y axis
        text1.rectTransform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        text2.rectTransform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        text3.rectTransform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        text4.rectTransform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        text5.rectTransform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        text6.rectTransform.position -= new Vector3(0, speed * Time.deltaTime, 0);
    }
}