using UnityEngine;

public class PlayParticleEffect : MonoBehaviour
{
    public GameObject particleEffectPrefab1;
    public GameObject particleEffectPrefab2;

    private ParticleSystem particleEffect1;
    private ParticleSystem particleEffect2;

    private void Start()
    {
        if (particleEffectPrefab1 != null)
        {
            // Instantiate the first particle effect prefab as a child of this object
            GameObject particleEffectObject1 = Instantiate(particleEffectPrefab1, transform);
            particleEffect1 = particleEffectObject1.GetComponent<ParticleSystem>();

            if (particleEffect1 != null)
            {
                particleEffect1.Play();
            }
        }
        else
        {
            Debug.LogWarning("Particle Effect Prefab 1 is not assigned to the PlayParticleEffect script on " + name);
        }

        if (particleEffectPrefab2 != null)
        {
            // Instantiate the second particle effect prefab as a child of this object
            GameObject particleEffectObject2 = Instantiate(particleEffectPrefab2, transform);
            particleEffect2 = particleEffectObject2.GetComponent<ParticleSystem>();

            if (particleEffect2 != null)
            {
                particleEffect2.Play();
            }
        }
        else
        {
            Debug.LogWarning("Particle Effect Prefab 2 is not assigned to the PlayParticleEffect script on " + name);
        }
    }
}