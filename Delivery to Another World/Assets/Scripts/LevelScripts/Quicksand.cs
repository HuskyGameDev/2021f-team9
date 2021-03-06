using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Quicksand : MonoBehaviour
{
    /// <summary>
    /// The script will cause the player to slide towards the center of the quicksand
    /// and if they are directly in the center, they will drown in the quicksand.
    /// </summary>

    public float forceMultiplier;

    private GameObject player;
    private Vector3 forceTowardsCenter;
    private float distanceToCenter;
    private bool forceActive;
    private bool holding;
    private PostProcessVolume volume;
    private Vignette vignette;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovementGravity>().gameObject;
        forceActive = false;
        holding = false;
        volume = FindObjectOfType<PostProcessVolume>();
        vignette = volume.profile.GetSetting<Vignette>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (forceActive)
        {
            distanceToCenter = Vector3.Distance(player.transform.position, transform.position);

            vignette.intensity.Interp(vignette.intensity, 1f, 1f);

            forceTowardsCenter = new Vector3(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y, transform.position.z - player.transform.position.z);
            forceTowardsCenter = Vector3.Normalize(forceTowardsCenter);
            player.GetComponent<CharacterController>().Move(forceTowardsCenter * forceMultiplier * Time.deltaTime);

            if (distanceToCenter < 0.1f && !holding)
            {
                StartCoroutine(HoldingBreath());
            }
        }
        else
        {
            vignette.intensity.Interp(vignette.intensity, 0f, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        forceActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        forceActive = false;
    }

    IEnumerator HoldingBreath()
    {
        holding = true;
        yield return new WaitForSeconds(2f);
        if (distanceToCenter < 0.1f)
        {
            forceActive = false;
            FindObjectOfType<EnemyVision>().SendMessage("GameOver");
            FindObjectOfType<PlayerMovementGravity>().GetComponent<Animator>().applyRootMotion = false;
            FindObjectOfType<PlayerMovementGravity>().GetComponent<Animator>().SetBool("inQuicksand", true);
        }
        holding = false;
    }
}
