using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Load : MonoBehaviour
{
    public GameObject obj;
    QuestManager data;
    public Load(GameObject obj)
    {
        this.obj = obj;
    }

    public void LoadSave()
    {
        data = obj.GetComponent<QuestManager>();
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
                                //data.apple = true;
                                PlayerPrefs.SetInt("apple", 1);
                                //data.quests[0].CompleteQuest();
                                //FindObjectOfType<QuestIndicator>().SendMessage("questCompleted");
                            }
                            else
                            {
                                PlayerPrefs.SetInt("apple", 0);
                            }
                        }
                        if (split[0].ToString().Equals("appleClaimed"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                //data.apple = true;
                                PlayerPrefs.SetInt("appleClaimed", 1);
                                //data.quests[0].CompleteQuest();
                                //FindObjectOfType<QuestIndicator>().SendMessage("questCompleted");
                            }
                            else
                            {
                                PlayerPrefs.SetInt("appleClaimed", 0);
                            }
                        }
                        if (split[0].ToString().Equals("finalcactus"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                PlayerPrefs.SetInt("finalcactus", 1);
                            }
                            else
                            {
                                PlayerPrefs.SetInt("finalcactus", 0);
                            }
                        }
                        if (split[0].ToString().Equals("finalcactusClaimed"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                PlayerPrefs.SetInt("finalcactusClaimed", 1);
                            }
                            else
                            {
                                PlayerPrefs.SetInt("finalcactusClaimed", 0);
                            }
                        }
                        if (split[0].ToString().Equals("epictome"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                PlayerPrefs.SetInt("epictome", 1);
                            }
                            else
                            {
                                PlayerPrefs.SetInt("epictome", 0);
                            }
                        }
                        if (split[0].ToString().Equals("epictomeClaimed"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                PlayerPrefs.SetInt("epictomeClaimed", 1);
                            }
                            else
                            {
                                PlayerPrefs.SetInt("epictomeClaimed", 0);
                            }
                        }
                        if (split[0].ToString().Equals("specialskull"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                PlayerPrefs.SetInt("specialskull", 1);
                            }
                            else
                            {
                                PlayerPrefs.SetInt("specialskull", 0);
                            }
                        }
                        if (split[0].ToString().Equals("specialskullClaimed"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                PlayerPrefs.SetInt("specialskullClaimed", 1);
                            }
                            else
                            {
                                PlayerPrefs.SetInt("specialskullClaimed", 0);
                            }
                        }
                        if (split[0].ToString().Equals("didYouWin"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                PlayerPrefs.SetInt("didYouWin", 1);
                            }
                            else
                            {
                                PlayerPrefs.SetInt("didYouWin", 0);
                            }
                        }
                        if (split[0].ToString().Equals("didYouWinClaimed"))
                        {
                            if (split[1].ToLower().Equals("true"))
                            {
                                PlayerPrefs.SetInt("didYouWinClaimed", 1);
                            }
                            else
                            {
                                PlayerPrefs.SetInt("didYouWinClaimed", 0);
                            }
                        }

                    }
                }
            }
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("Hub");
    }
}