using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightingCode : MonoBehaviour
{

    public PostProcessVolume volume;

    private bool dimensionActive;
    private ChromaticAberration dimensionEffect;
    private Vignette vignetteEffect;
    private GameObject player;
    private EnemyMovement[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        dimensionEffect = volume.profile.GetSetting<ChromaticAberration>();
        vignetteEffect = volume.profile.GetSetting<Vignette>();
        player = FindObjectOfType<PlayerMovementGravity>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        dimensionActive = FindObjectOfType<RotationGravity>().dimensionActive;
        enemies = FindObjectsOfType<EnemyMovement>();

        // Adds the Chromatic Aberration effect when in the other dimension
        if (dimensionActive)
        {
            dimensionEffect.intensity.Interp(dimensionEffect.intensity, 1f, 1f * Time.deltaTime);
        }
        else
        {
            dimensionEffect.intensity.Interp(dimensionEffect.intensity, 0f, 1f * Time.deltaTime);
        }

        // Finds the closest enemy to the player
        for (int i = 0; i < enemies.Length; i++)
        {
            float x = player.transform.position.x - enemies[i].gameObject.transform.position.x;
            float z = player.transform.position.z - enemies[i].gameObject.transform.position.z;
            float distance = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(z, 2));

            // If the player is closer than 5 units away from an enemy start showing the vignette effect
            if(distance < 5f)
            {
                // Vignette effect gets stronger the close the player gets to the enemy
                float percentage = distance / 5f;
                percentage = 1f - percentage;
                float intensityValue = 0.5f * percentage;
                vignetteEffect.intensity.Interp(vignetteEffect.intensity, intensityValue, 1f);
                break;
            }
            else
            {
                vignetteEffect.intensity.Interp(vignetteEffect.intensity, 0f, 1f);
            }
        }
    }
}
