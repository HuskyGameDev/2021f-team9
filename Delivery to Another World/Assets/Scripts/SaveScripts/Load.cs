using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Load : MonoBehaviour
{
    public GameObject obj;
    SaveData data;
    public Load(GameObject obj)
    {
        this.obj = obj;
    }

    public void LoadSave()
    {
        data = obj.GetComponent<SaveData>();
        if (File.Exists(Application.persistentDataPath + "\\savedata.heheh"))
        {
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
                            if (split[1].ToLower().Equals("true"))
                            {
                                data.isDragonDefeated = true;
                            }
                            else
                            {
                                data.isDragonDefeated = false;
                            }
                        }
                        if (split[0].ToString().Equals("isCactusFound"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                data.isCactusFound = true;
                            }
                            else
                            {
                                data.isCactusFound = false;
                            }
                        }
                        if (split[0].ToString().Equals("ownOasisWater"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                data.ownOasisWater = true;
                            }
                            else
                            {
                                data.ownOasisWater = false;
                            }
                        }
                        if (split[0].ToString().Equals("doYouOwnAPicnicBasket"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                data.doYouOwnAPicnicBasket = true;
                            }
                            else
                            {
                                data.doYouOwnAPicnicBasket = false;
                            }
                        }
                        if (split[0].ToString().Equals("haveTheGremlinsScoldedYou"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                data.haveTheGremlinsScoldedYou = true;
                            }
                            else
                            {
                                data.haveTheGremlinsScoldedYou = false;
                            }
                        }
                        if (split[0].ToString().Equals("didYouWin"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                data.didYouWin = true;
                            }
                            else
                            {
                                data.didYouWin = false;
                            }
                        }

                    }
                }
            }
        }
    }
}