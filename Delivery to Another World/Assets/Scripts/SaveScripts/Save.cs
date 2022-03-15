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

    public static Save instance { get { return instance; } }

    public GameObject obj; //GameObject.FindGameObjectsWithTag("SaveData")[0].GetComponent<SaveData>(); //Should only be one
    //public GameObject playerObj;

    bool apple;
    bool epictome;
    bool finalcactus;
    bool specialskull;
    bool didYouWin;


    public Save(GameObject obj)
    {
        this.obj = obj;
    }

    public void save()
    {

        QuestManager data = obj.GetComponent<QuestManager>();

        apple = data.quests[0].isQuestComplete();
        //epictome = data.quests[1].isQuestComplete();
        finalcactus = data.quests[1].isQuestComplete();
        //specialskull = data.specialskull;
        //didYouWin = data.didYouWin;

        //temp till we fix all quests later
        epictome = false;
        specialskull = false;
        didYouWin = false;

        //Overwrite data
        using (StreamWriter writer = File.CreateText(Application.persistentDataPath + "\\savedata.heheh"))
        {
            writer.WriteLine("apple:" + apple);
            writer.WriteLine("epictome:" + epictome);
            writer.WriteLine("finalcactus:" + finalcactus);
            writer.WriteLine("specialskull:" + specialskull);
            writer.WriteLine("didYouWin:" + didYouWin);

        }
    }

    
}
