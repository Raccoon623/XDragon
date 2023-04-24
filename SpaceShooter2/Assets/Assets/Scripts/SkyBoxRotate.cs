using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public float exposureSpeed = 0.5f;
    private Material skyboxMaterial;

    void Start()
    {
        // Get a reference to the skybox material
        skyboxMaterial = RenderSettings.skybox;
    }

    void Update()
    {
        // Modify the rotation of the skybox material
        float rotation = Time.time * rotationSpeed;
        skyboxMaterial.SetFloat("_Rotation", rotation);

        // Modify the exposure of the skybox material
        float exposure = 1.0f + Mathf.Sin(Time.time * exposureSpeed) * 0.5f;
        skyboxMaterial.SetFloat("_Exposure", exposure);
    }
}