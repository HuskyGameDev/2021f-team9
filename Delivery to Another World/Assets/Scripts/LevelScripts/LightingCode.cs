using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightingCode : MonoBehaviour
{

    public PostProcessVolume volume;

    private bool startEffect;
    private LensDistortion dimensionEffect;
    private Vignette vignetteEffect;
    private GameObject player;
    private EnemyMovement[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        dimensionEffect = volume.profile.GetSetting<LensDistortion>();
        vignetteEffect = volume.profile.GetSetting<Vignette>();
        player = FindObjectOfType<PlayerMovementGravity>().gameObject;
        startEffect = false;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = FindObjectsOfType<EnemyMovement>();

        // Finds the closest enemy to the player
        for (int i = 0; i < enemies.Length; i++)
        {
            float distance = Vector3.Distance(player.transform.position, enemies[i].gameObject.transform.position);

            // If the player is closer than 5 units away from an enemy start showing the vignette effect
            if(distance < 5f)
            {
                // Vignette effect gets stronger the closer the player gets to the enemy
                float percentage = distance / 5f;
                percentage = 1f - percentage;
                float intensityValue = 0.6f * percentage;
                vignetteEffect.intensity.Interp(vignetteEffect.intensity, intensityValue, 1f);
                break;
            }
            else
            {
                vignetteEffect.intensity.Interp(vignetteEffect.intensity, 0f, 1f);
            }
        }
    }

    private void FixedUpdate()
    {
        /*canTurn = FindObjectOfType<RotationGravity>().canTurn;
        dimensionActive = FindObjectOfType<RotationGravity>().dimensionActive;

        if (Input.GetKeyDown(KeyCode.R) && canTurn)
        {
            StartCoroutine(DimensionEffect());
        }*/

        if (startEffect)
        {
            dimensionEffect.intensity.Interp(dimensionEffect.intensity, -100f, Time.deltaTime / 0.15f);
        }
        else
        {
            dimensionEffect.intensity.Interp(dimensionEffect.intensity, 0f, Time.deltaTime / 0.35f);
        }
    }

    public IEnumerator DimensionEffect()
    {
        startEffect = true;
        yield return new WaitForSeconds(0.25f);
        startEffect = false;
    }
}
