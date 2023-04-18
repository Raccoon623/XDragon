using MinimalShooting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireKey : MonoBehaviour
{
    [Header("Bullet prafab")]
    [SerializeField]
    Bullet prefabBullet;

    [Header("Interval between each fire")]
    [SerializeField]
    float interval = 1.0f;

    [Header("Bullet speed")]
    [SerializeField]
    float speed = 40.0f;

    [Header("Fire direction")]
    [SerializeField]
    Vector3 direction = new Vector3(0, 0, 1);

    [Header("Fire to player or not")]
    // If this sets true, bullets will be shoot towards to player.
    // If this sets false, it will be use the direction variable above.
    [SerializeField]
    bool toPlayer = false;

    [Header("Missile")]
    // If this sets true, bullets will be shoot towards to enemies.
    [SerializeField]
    bool isMissile = false;

    private void OnEnable()
    {
        StartCoroutine(FireLoop());
    }

    IEnumerator FireLoop()
    {
        GameObject player = GameObject.Find("Player");

        while (true)
        {
            // Check if spacebar key is being held down.
            if (Input.GetKey(KeyCode.Space))
            {
                // Fire bullet.
                Bullet bullet = GameObject.Instantiate(this.prefabBullet);
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;

                bullet.SetDirection(transform.forward);
                bullet.SetSpeed(this.speed);

                if (this.toPlayer)
                {
                    if (player != null)
                    {
                        this.direction = (player.transform.position - transform.position).normalized;
                        bullet.transform.rotation = Quaternion.LookRotation(this.direction);
                        bullet.SetDirection(this.direction);
                    }
                }

                if (this.isMissile)
                {
                    bullet.SetFollowTarget();
                }

                yield return new WaitForSeconds(this.interval);
            }
            else
            {
                yield return null;
            }
        }

    }
}




