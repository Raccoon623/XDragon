using UnityEngine;

public class RandomBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector3 moveDirection;

    private void Start()
    {
        // Set a random move direction
        moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }

    private void Update()
    {
        // Move in the current move direction
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
