using MinimalShooting;
using UnityEngine;
public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable the object
            gameObject.SetActive(false);

            // Toggle the FireKey script on the player's body
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                Transform bodyTransform = player.transform.Find("Body");
                if (bodyTransform != null)
                {
                    FireKey fireKeyScript = bodyTransform.GetComponent<FireKey>();
                    if (fireKeyScript != null)
                    {
                        fireKeyScript.enabled = !fireKeyScript.enabled;
                    }
                }
            }
        }
    }
}