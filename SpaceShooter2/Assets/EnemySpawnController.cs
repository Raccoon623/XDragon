using UnityEngine;
using System.Collections;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject EnemySpawner;
    public GameObject EnemySpawner2;

    IEnumerator Start()
    {
        // Wait for 10 seconds
        yield return new WaitForSeconds(20);

        // Toggle the game objects
        EnemySpawner.SetActive(false);
        EnemySpawner2.SetActive(false);
    }
}
