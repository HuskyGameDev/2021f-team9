using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HubDoor : MonoBehaviour
{
    public GameObject forestButton;
    public GameObject desertButton;
    public GameObject caveButton;
    public GameObject castleButton;

    GameObject map;
    QuestManager questManager;

    private void Start()
    {
        map = GameObject.FindGameObjectWithTag("Map");
        map.SetActive(false);
        FindObjectOfType<Transition>().SendMessage("transition");
        questManager = FindObjectOfType<QuestManager>();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 1.0f)
        {
            if (!map.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                map.SetActive(true);

                FindObjectOfType<PlayerMovementGravity>().enabled = false;
                FindObjectOfType<RotationGravity>().enabled = false;

                forestButton.GetComponent<Button>().enabled = false;
                desertButton.GetComponent<Button>().enabled = false;
                caveButton.GetComponent<Button>().enabled = false;
                castleButton.GetComponent<Button>().enabled = false;

                forestButton.GetComponent<Image>().color = Color.grey;
                desertButton.GetComponent<Image>().color = Color.grey;
                caveButton.GetComponent<Image>().color = Color.grey;
                castleButton.GetComponent<Image>().color = Color.grey;

                Quest quest1 = questManager.GetQuest1();
                Quest quest2 = questManager.GetQuest2();

                if (!quest1.isNewQuest && questManager.questActive)
                {
                    if (quest1.questArea.Equals("Forest"))
                    {
                        forestButton.GetComponent<Button>().enabled = true;
                        forestButton.GetComponent<Image>().color = Color.white;
                    }
                    else if (quest1.questArea.Equals("Desert"))
                    {
                        desertButton.GetComponent<Button>().enabled = true;
                        desertButton.GetComponent<Image>().color = Color.white;
                    }
                    // Uncomment these when cave and castle have been implemented
                    /*else if (quest1.questArea.Equals("Cave"))
                    {
                        caveButton.GetComponent<Button>().enabled = true;
                        caveButton.GetComponent<Image>().color = Color.white
                    }*/
                    /*else if (quest1.questArea.Equals("Castle"))
                    {
                        castleButton.GetComponent<Button>().enabled = true;
                        castleButton.GetComponent<Image>().color = Color.white;
                    }*/
                }

                if (!quest2.isNewQuest && questManager.questActive)
                {
                    if (quest2.questArea.Equals("Forest"))
                    {
                        forestButton.GetComponent<Button>().enabled = true;
                        forestButton.GetComponent<Image>().color = Color.white;
                    }
                    else if (quest2.questArea.Equals("Desert"))
                    {
                        desertButton.GetComponent<Button>().enabled = true;
                        desertButton.GetComponent<Image>().color = Color.white;
                    }
                    // Uncomment these when cave and castle have been implemented
                    /*else if (quest2.questArea.Equals("Cave"))
                    {
                        caveButton.GetComponent<Button>().enabled = true;
                        caveButton.GetComponent<Image>().color = Color.white;
                    }*/
                    /*else if (quest2.questArea.Equals("Castle"))
                    {
                        castleButton.GetComponent<Button>().enabled = true;
                        castleButton.GetComponent<Image>().color = Color.white;
                    }*/
                }
            }
        }
    }

    public void ExitMap()
    {
        FindObjectOfType<PlayerMovementGravity>().enabled = true;
        FindObjectOfType<RotationGravity>().enabled = true;
        map.SetActive(false);
    }
}
