using UnityEngine;
using System.Collections;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject[] enemySpawners;
    public float[] activationTimes;
    public float[] deactivationTimes;

    void Start()
    {
        // Make sure the arrays have the same length
        if (enemySpawners.Length != activationTimes.Length || enemySpawners.Length != deactivationTimes.Length)
        {
            Debug.LogError("Number of enemy spawners, activation times, and deactivation times must be the same.");
            return;
        }

        // Start coroutines for each enemy spawner
        for (int i = 0; i < enemySpawners.Length; i++)
        {
            StartCoroutine(ToggleEnemySpawner(i));
        }
    }

    IEnumerator ToggleEnemySpawner(int index)
    {
        // Wait for the activation time
        yield return new WaitForSeconds(activationTimes[index]);

        // Activate the enemy spawner
        enemySpawners[index].SetActive(true);

        // Wait for the deactivation time
        yield return new WaitForSeconds(deactivationTimes[index]);

        // Deactivate the enemy spawner
        enemySpawners[index].SetActive(false);
    }
}