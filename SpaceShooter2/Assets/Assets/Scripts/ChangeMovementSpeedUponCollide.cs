using MinimalShooting.ControllerPackage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimalShooting
{
    public class ChangeMovementSpeedUponCollide : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SimpleMovement movement = other.gameObject.GetComponent<SimpleMovement>();
                if (movement != null)
                {
                    movement.KeyboardMovementSpeed = 6f;

                    // Destroy this object
                    Destroy(gameObject);
                }
            }
        }
    }
}
