using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }
}