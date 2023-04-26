using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MinimalShooting
{
    /// <summary>
    /// Enemy
    /// This class implements an enemy.
    /// </summary>
    public class Boss : MonoBehaviour
    {
        enum MovementType
        {
            Straight,
            Zigzag,
            ToPlayer,
            Circle,
        }

        [Header("Prefab damage")]
        [SerializeField]
        GameObject prefabDamage;

        [Header("Prefab explosion")]
        [SerializeField]
        GameObject prefabExplosion;

        [Header("Movement speed")]
        [Space(20)]
        [SerializeField]
        float speedMin = 4.0f;

        [SerializeField]
        float speedMax = 7.0f;

        [Header("Max HP")]
        [SerializeField]
        float maxHp = 10.0f;

        [Header("Movement direction")]
        [SerializeField]
        Vector3 direction = new Vector3(0, 0, -1);

        [Header("Movement type")]
        [SerializeField]
        MovementType movementType;

        // Private variables.
        float speed;
        float currentHp;
        Vector3 hiddenPosition;
        GameObject trailObject;
        List<Weapon> weapons;
        GameObject player;

        public void Awake()
        {
            this.player = GameObject.Find("Player");
            this.weapons = new List<Weapon>(GetComponentsInChildren<Weapon>());
            
            // Set the maxHp to 10.
            this.maxHp = 10.0f;

            // Set hidden position to current position.
            // If the movement type will be sets Circle, this variable will be used to let Transform move down.
            this.hiddenPosition = transform.position;

            // Some enemies have own their trail renderer.
            // Create new GameObject for it, attatch the trail to the new object.
            // It because the trail have to be alive even the enemy had been destroyed.
            if (transform.Find("Trail") != null)
            {
                this.trailObject = new GameObject(transform.name + "_trail");
                transform.Find("Trail").SetParent(this.trailObject.transform, false);
            }

            // This determines random movement speed.
            this.speed = Random.Range(this.speedMin, this.speedMax);

            // Calculate self-rotation speed.
            float speedRate = this.speed / this.speedMin;
            GetComponentInChildren<Rotator>().SetSpeedOption(speedRate);

            // Determine direction if movementType is ToPlayer.
            if (this.movementType == MovementType.ToPlayer)
            {
                // Find the Player object.
                // If the movement type will be sets ToPlayer, this variable will be used to follow the player.
                if (this.player != null)
                {
                    this.direction = (this.player.transform.position - transform.position).normalized;
                }
            }
        }


        /// <summary>
        /// When the enemy gets damaged.
        /// </summary>
        /// <param name="collisionPoint"></param>
        public void OnDamage(Vector3 collisionPoint)
        {
            // Instantiate the damage effect.
            GameObject.Instantiate(this.prefabDamage, collisionPoint, Quaternion.identity);

            // Blink the object.
            if (GetComponentInChildren<MaterialChanger>() != null)
            {
                GetComponentInChildren<MaterialChanger>().enabled = true;
            }

            // Decrease current hp.
            this.currentHp -= 1.0f;

            // If the current hp is less than or equal to zero, destroy the boss.
            if (this.currentHp <= 0.0f)
            {
                DestroyNow();
            }
            else if (this.currentHp % 5 == 0) // Boss will flash every 5 hits.
            {
                StartCoroutine(Flash());
            }
        }

        private IEnumerator Flash()
        {
            // Get all the materials in the child game objects.
            Material[] materials = GetComponentsInChildren<Renderer>().SelectMany(r => r.materials).ToArray();

            // Change the materials to the flashing material.
            foreach (Material material in materials)
            {
                material.color = Color.red;
            }

            // Wait for a short time.
            yield return new WaitForSeconds(0.1f);

            // Change the materials back to their original colors.
            foreach (Material material in materials)
            {
                material.color = Color.white;
            }
        }

        public void DestroyNow()
        {
            // Instantiate the destroy effect.
            GameObject.Instantiate(this.prefabExplosion, transform.position, Quaternion.identity);

            // Set auto destroy property, if this has an trail object.
            if (this.trailObject != null)
            {
                SelfDestroyed selfDestroy = this.trailObject.AddComponent<SelfDestroyed>();
                // Disable coroutine to prevent destroy itself.
                selfDestroy.enabled = false;
                // Set delay.
                selfDestroy.SetDelay(5.0f);
                // Enable it.
                selfDestroy.enabled = true;
            }

            // Destroy this enemey.
            Destroy(gameObject);
        }


        // Update is called once per frame
        void Update()
        {
            MoveByType();
            MoveTrailObject();
            CheckWeapons();
            CheckArea();
        }


        /// <summary>
        /// Move the transform by its movement type.
        /// </summary>
        void MoveByType()
        {
            // The velocity is always 'current direction * speed'
            Vector3 velocity = this.direction * this.speed;

            switch (this.movementType)
            {
                case MovementType.Straight:
                    {
                        // Simple, move straight.
                        transform.position += Time.deltaTime * velocity;
                    }
                    break;

                case MovementType.Zigzag:
                    {
                        // Move by velocity.
                        transform.position += Time.deltaTime * velocity;

                        Vector3 pos = transform.position;

                        // How fast turn it can be.
                        float rate = 3.0f;

                        // Calculate x variable to move zigzag.
                        float x = Mathf.Cos(Time.time * rate);

                        // Cos returns -1 ~ +1, so we should multiply a radius to get the final position.
                        float radius = 3.0f;
                        pos.x = x * radius;

                        // Apply it. x variable from Cos, other variables from the velocity.
                        transform.position = pos;
                    }
                    break;

                case MovementType.ToPlayer:
                    {
                        // The velocity already sets to player, so it is same as the Straight formula.
                        transform.position += Time.deltaTime * velocity;
                    }
                    break;

                case MovementType.Circle:
                    {
                        // Radius.
                        float radius = 2.5f;

                        // How fast turn it can be.
                        float rate = 4.0f;
                        float z = Mathf.Sin(Time.time * rate) * radius;
                        float x = Mathf.Cos(Time.time * rate) * radius;
                        Vector3 localCirclePosition = new Vector3(x, 0, z);

                        // Calculate the body position to move down.
                        this.hiddenPosition += Time.deltaTime * velocity;

                        // The final position is combined with two vectors.
                        // One is its own position.
                        // Another is the circle position.
                        transform.position = this.hiddenPosition + localCirclePosition;
                    }
                    break;
            }
        }


        /// <summary>
        /// Move the trail manually, because it is a separated object from the this enemy.
        /// </summary>
        void MoveTrailObject()
        {
            if (this.trailObject != null)
            {
                this.trailObject.transform.position = transform.position;
            }
        }


        void CheckWeapons()
        {
            if (this.player == null)
            {
                return;
            }

            if (transform.position.z < this.player.transform.position.z)
            {
                foreach (Weapon weapon in this.weapons)
                {
                    weapon.gameObject.SetActive(false);
                }
            }
        }


        void CheckArea()
        {
            // It is destroy when position is over.
            if (transform.position.z >= 20.0f ||
                transform.position.z <= -20.0f ||
                transform.position.x >= 7.0f ||
                transform.position.x <= -7.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
