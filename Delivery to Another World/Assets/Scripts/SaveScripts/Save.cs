using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Save
{
    int number = 0;
    public void save()
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
                        if (split[0].ToString().Equals("number"))
                        {
                            number = int.Parse(split[1]);
                            Debug.Log("New Number is: " + number);
                        }
                    }
                    else
                    {
                        Debug.Log("Something is wrong with the save file");
                    }
                }
            }
        }
        
        //Overwrite data
        using (StreamWriter writer = File.CreateText(Application.persistentDataPath + "\\savedata.heheh"))
        {
            writer.WriteLine("number:" + number);
        }
    }

    
}
