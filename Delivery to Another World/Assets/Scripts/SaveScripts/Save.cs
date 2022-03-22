using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save
{
    /*
     * 
     * List or static number of bools completed goes into list
     * 
     */

    QuestManager data;

    //public static Save instance { get { return instance; } }

    public GameObject obj; //GameObject.FindGameObjectsWithTag("SaveData")[0].GetComponent<SaveData>(); //Should only be one
    //public GameObject playerObj;

    bool apple;
    bool finalcactus;
    bool epictome;
    bool specialskull;
    bool didYouWin;

    bool appleC;
    bool finalcactusC;
    bool epictomeC;
    bool specialskullC;
    bool didYouWinC;

    public Save(GameObject obj)
    {
        this.obj = obj;
        data = obj.GetComponent<QuestManager>();
    }

    public void save()
    {

        apple = data.quests[0].isQuestComplete();
        finalcactus = data.quests[1].isQuestComplete();
        epictome = data.quests[2].isQuestComplete();
        specialskull = data.quests[3].isQuestComplete();
        didYouWin = data.quests[4].isQuestComplete();

        appleC = data.quests[0].isQuestClaimed();
        finalcactusC = data.quests[1].isQuestClaimed();
        epictomeC = data.quests[2].isQuestClaimed();
        specialskullC = data.quests[3].isQuestClaimed();
        didYouWinC = data.quests[4].isQuestClaimed();

        //Overwrite data
        using (StreamWriter writer = File.CreateText(Application.persistentDataPath + "\\savedata.heheh"))
        {
            writer.WriteLine("apple:" + apple);
            writer.WriteLine("finalcactus:" + finalcactus);
            writer.WriteLine("epictome:" + epictome);
            writer.WriteLine("specialskull:" + specialskull);
            writer.WriteLine("didYouWin:" + didYouWin);

            writer.WriteLine("appleClaimed:" + appleC);
            writer.WriteLine("finalcactusClaimed:" + finalcactusC);
            writer.WriteLine("epictomeClaimed:" + epictomeC);
            writer.WriteLine("specialskullClaimed:" + specialskullC);
            writer.WriteLine("didYouWinClaimed:" + didYouWinC);

        }
    }

    
}
