using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HubDoor : MonoBehaviour
{
    public GameObject forestButton;
    public GameObject desertButton;
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

                forestButton.GetComponent<Button>().interactable = false;
                desertButton.GetComponent<Button>().interactable = false;
                // Uncomment these when cave and castle have been implemented
                //caveButton.GetComponent<Button>().interactable = false;
                //castleButton.GetComponent<Button>().interactable = false;

                string quest1Area = questManager.GetQuest1();
                string quest2Area = questManager.GetQuest2();

                if (quest1Area.Equals("Forest") || quest2Area.Equals("Forest"))
                    forestButton.GetComponent<Button>().interactable = true;

                if (quest1Area.Equals("Desert") || quest2Area.Equals("Desert"))
                    desertButton.GetComponent<Button>().interactable = true;

                /*if (quest1Area.Equals("CASTLE") || quest2Area.Equals("CASTLE"))
                    castleButton.GetComponent<Button>().interactable = true;*/
            }

            if (map.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            {
                ExitMap();
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
