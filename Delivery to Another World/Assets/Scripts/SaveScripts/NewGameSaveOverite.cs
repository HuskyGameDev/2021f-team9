using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameSaveOverite : MonoBehaviour
{
    public GameObject saveDataObj;
    public Button yourButton;
    Save save;

    //Awake is called on instantion
    private void Awake()
    {
        save = new Save(saveDataObj);
    }

    //Awake is called once the script is called
    void Start()
    {
        //If the button is clicked go to TaskOnClick()
        yourButton.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
 
    }

    //This overwrites the save file and goes to the Hub
    void TaskOnClick()
    {
        save.save();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Hub");
    }
    
}
