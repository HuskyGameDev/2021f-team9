using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Save
{ 
    /*
     * 
     * List or static number of bools completed goes into list
     * 
     */

    public static Save instance { get { return instance; } }

    public GameObject obj; //GameObject.FindGameObjectsWithTag("SaveData")[0].GetComponent<SaveData>(); //Should only be one

    bool isDragonDefeated;
    bool isCactusFound;
    bool ownOasisWater;
    bool doYouOwnAPicnicBasket;
    bool haveTheGremlinsScoldedYou;
    bool didYouWin;

    public Save(GameObject obj)
    {
        this.obj = obj;
    }

    public void save()
    {

        SaveData data = obj.GetComponent<SaveData>();

        isDragonDefeated = data.isDragonDefeated;
        isCactusFound = data.isCactusFound;
        ownOasisWater = data.ownOasisWater;
        doYouOwnAPicnicBasket = data.doYouOwnAPicnicBasket;
        haveTheGremlinsScoldedYou = data.haveTheGremlinsScoldedYou;
        didYouWin = data.didYouWin;

        //Overwrite data
        using (StreamWriter writer = File.CreateText(Application.persistentDataPath + "\\savedata.heheh"))
        {
            writer.WriteLine("isDragonDefeated:" + isDragonDefeated);
            writer.WriteLine("isCactusFound:" + isCactusFound);
            writer.WriteLine("ownOasisWater:" + ownOasisWater);
            writer.WriteLine("doYouOwnAPicnicBasket:" + doYouOwnAPicnicBasket);
            writer.WriteLine("haveTheGremlinsScoldedYou:" + haveTheGremlinsScoldedYou);
            writer.WriteLine("didYouWin:" + didYouWin);
        }
    }

    
}
