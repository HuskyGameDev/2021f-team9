using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubTreasures : MonoBehaviour
{

    public MeshRenderer treasureRenderer;
    public Light spotLight;
    public GameObject particles;
    public int treasureNum;

    private QuestManager qstMngr;

    // Start is called before the first frame update
    void Start()
    {
        treasureNum--;
        qstMngr = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (qstMngr.quests[treasureNum].isQuestComplete())
        {
            treasureRenderer.enabled = true;
            spotLight.enabled = true;
            particles.SetActive(true);
        }
    }
}
