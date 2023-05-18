using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplosion : MonoBehaviour
{
    public GameObject explosionPrefab; // Reference to the explosion prefab

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Instantiate the explosion effect at the missile's position
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Destroy the missile
            Destroy(gameObject);
        }
    }
}