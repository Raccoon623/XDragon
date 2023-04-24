using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Spawner : MonoBehaviour
{
    public GameObject ufoBossPrefab;
    public float spawnDelay = 10f;

    void Start()
    {
        Invoke("SpawnUFOBoss", spawnDelay);
    }

    void SpawnUFOBoss()
    {
        GameObject ufoBoss = Instantiate(ufoBossPrefab, transform.position, Quaternion.identity);
        ufoBoss.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
    }
}
