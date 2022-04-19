using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEntranceCutscene : MonoBehaviour
{
    private GameObject player;
    public GameObject playerWaypoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        DisablePlayer();
        MoveCamera();
    }

    private void DisablePlayer()
    {
        player.GetComponent<PlayerMovementGravity>().enabled = false;

        if (player.GetComponent<RotationGravity>().dimensionActive)
        {
            player.GetComponent<RotationGravity>().Flipper();
        }

        player.GetComponent<RotationGravity>().enabled = false;

        StartCoroutine(MovePlayer());
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
        Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, 7.45f, 23f);
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
