using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float effectDuration = 0.5f;

    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= effectDuration)
        {
            Destroy(gameObject);
        }
    }
}
