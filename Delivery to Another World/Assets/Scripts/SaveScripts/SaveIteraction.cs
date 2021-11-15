using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveIteraction : MonoBehaviour
{
    public GameObject saveDataObj;
    public GameObject playerObj;
    bool isDragonDefeated;
    bool isCactusFound;
    bool ownOasisWater;
    bool doYouOwnAPicnicBasket;
    bool haveTheGremlinsScoldedYou;
    bool didYouWin;
    Save save;


    private void Awake()
    {
        save = new Save(saveDataObj);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerObj.transform.position) < 20.0f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                save.save();
                //Save();
            }
        }
    }

    void Save ()
    {
        if (File.Exists(Application.persistentDataPath + "\\savedata.heheh"))
        {
            //Read Data

            using (StreamReader reader = File.OpenText(Application.persistentDataPath + "\\savedata.heheh"))
            {
                string tempLine = "";
                while ((tempLine = reader.ReadLine()) != null)
                {
                    string[] split = tempLine.Split(':');
                    if (split.Length >= 2)
                    {
                        if (split[0].ToString().Equals("isDragonDefeated"))
                        {
                            if (split[1].Equals("true"))
                            {
                                isDragonDefeated = true;
                            }
                            else
                            {
                                isDragonDefeated = false;
                            }
                        }
                        if (split[0].ToString().Equals("isCactusFound"))
                        {
                            if (split[1].Equals("true"))
                            {
                                isCactusFound = true;
                            }
                            else
                            {
                                isCactusFound = false;
                            }
                        }
                        if (split[0].ToString().Equals("ownOasisWater"))
                        {
                            if (split[1].Equals("true"))
                            {
                                ownOasisWater = true;
                            }
                            else
                            {
                                ownOasisWater = false;
                            }
                        }
                        if (split[0].ToString().Equals("doYouOwnAPicnicBasket"))
                        {
                            if (split[1].Equals("true"))
                            {
                                doYouOwnAPicnicBasket = true;
                            }
                            else
                            {
                                doYouOwnAPicnicBasket = false;
                            }
                        }
                        if (split[0].ToString().Equals("haveTheGremlinsScoldedYou"))
                        {
                            if (split[1].Equals("true"))
                            {
                                haveTheGremlinsScoldedYou = true;
                            }
                            else
                            {
                                haveTheGremlinsScoldedYou = false;
                            }
                        }
                        if (split[0].ToString().Equals("didYouWin"))
                        {
                            if (split[1].Equals("true"))
                            {
                                didYouWin = true;
                            }
                            else
                            {
                                didYouWin = false;
                            }
                        }

                    }
                    else
                    {
                        Debug.Log("Something is wrong with the save file");
                    }
                }
            }
        }
        else
        {
            isDragonDefeated = false;
            isCactusFound = false;
            ownOasisWater = false;
            doYouOwnAPicnicBasket = false;
            haveTheGremlinsScoldedYou = false;
            didYouWin = false;
        }

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