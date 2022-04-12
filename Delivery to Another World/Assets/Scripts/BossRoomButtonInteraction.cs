using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossButtonInteraction : MonoBehaviour
{

    public GameObject player;
    public BossRoomButtons bossManager;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.0f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                bossManager.pressedNextButton();
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
