using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEntranceCutscene : MonoBehaviour
{
    private GameObject player;
    public GameObject playerWaypoint;
    private Vector3 cameraPosition;
    private bool cameraBack;
    public MeshRenderer GeoffryLeftEye;
    public MeshRenderer GeoffryRightEye;
    public GameObject DialogueBox;
    public Text dialogueText;
    [TextArea(3, 10)]
    public string[] dialogue;
    private int index;
    public GameObject Geoffry;
    public Light Vision;
    public GameObject DetectionZone;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraPosition = Camera.main.transform.localPosition;
        cameraBack = false;
        index = 0;
    }

    public void DisablePlayer()
    {
        player.GetComponent<PlayerMovementGravity>().enabled = false;

        if (player.GetComponent<RotationGravity>().dimensionActive)
        {
            player.GetComponent<RotationGravity>().Flipper();
        }

        player.GetComponent<RotationGravity>().enabled = false;
    }

    public void EnablePlayer()
    {
        player.GetComponent<PlayerMovementGravity>().enabled = true;
        player.GetComponent<RotationGravity>().enabled = true;
    }

    public void ControlPlayer()
    {
        player.transform.position = playerWaypoint.transform.position;
    }

    public void MoveCamera()
    {
        StartCoroutine(CameraMovement());
    }

    public void Awaken()
    {
        GeoffryLeftEye.enabled = true;
        GeoffryRightEye.enabled = true;
    }

    public void PlayBossDialogue()
    {
        DialogueBox.SetActive(true);
        dialogueText.text = dialogue[index++];
    }

    public void HideDialogue()
    {
        DialogueBox.SetActive(false);
    }

    public void BossActivate()
    {
        Geoffry.GetComponent<BossVision>().enabled = true;
        Vision.enabled = true;
        DetectionZone.SetActive(true);
    }

    private IEnumerator CameraMovement()
    {
        Vector3 startingPos = Camera.main.transform.localPosition;
        //Vector3 finalPos = transform.position + (transform.forward * 5);
        Vector3 finalPos = new Vector3(Camera.main.transform.localPosition.x, 7.45f, 23f);
        float elapsedTime = 0;
        float time = 1;
        float startTime = Time.time;

        // Move the camera back to the player
        if (cameraBack)
        {
            while (elapsedTime < time)
            {
                elapsedTime = Time.time - startTime;
                Camera.main.transform.localPosition = Vector3.Lerp(startingPos, cameraPosition, (elapsedTime / time));
                //elapsedTime += Time.deltaTime;
                cameraBack = false;
                yield return null;
            }
        }
        // Move the camera to GEOFFRY
        else
        {
            while (elapsedTime < time)
            {
                elapsedTime = Time.time - startTime;
                Camera.main.transform.localPosition = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
                //elapsedTime += Time.deltaTime;
                cameraBack = true;
                yield return null;
            }
        }
    }
}
