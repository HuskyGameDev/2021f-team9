using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEntranceCutscene : MonoBehaviour
{
    public GameObject player;
    public GameObject playerWaypoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        DisablePlayer();

    }

    private void DisablePlayer()
    {
        player.GetComponent<PlayerMovementGravity>().enabled = false;

        if (player.GetComponent<RotationGravity>().dimensionActive)
        {
            player.GetComponent<RotationGravity>().Flipper();
        }

        player.GetComponent<RotationGravity>().enabled = false;
    }

    private void EnablePlayer()
    {
        player.GetComponent<PlayerMovementGravity>().enabled = true;
        player.GetComponent<RotationGravity>().enabled = true;
    }

    private void ControlPlayer()
    {
       
    }

    private void MoveCamera()
    {

    }

    private IEnumerator MovePlayer()
    {
        Vector3 startingPos = transform.position;
        Vector3 finalPos = transform.position + (transform.forward * 5);
        float elapsedTime = 0;
        float time = 1;

        while (elapsedTime < time)
        {
            player.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
