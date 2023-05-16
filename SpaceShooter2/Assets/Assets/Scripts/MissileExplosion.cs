using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplosion : MonoBehaviour

{
    public GameObject explosionPrefab; // Reference to the explosion prefab

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the missile collided with the target
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Instantiate the explosion effect at the collision point
            Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);
        }
    }
}
