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
                        if (split[0].ToString().Equals("apple"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                data.apple = true;
                            }
                            else
                            {
                                data.apple = false;
                            }
                        }
                        if (split[0].ToString().Equals("epictome"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                data.epictome = true;
                            }
                            else
                            {
                                data.epictome = false;
                            }
                        }
                        if (split[0].ToString().Equals("finalcactus"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                data.finalcactus = true;
                            }
                            else
                            {
                                data.finalcactus = false;
                            }
                        }
                        if (split[0].ToString().Equals("specialskull"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                data.specialskull = true;
                            }
                            else
                            {
                                data.specialskull = false;
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("Hub");
    }
}