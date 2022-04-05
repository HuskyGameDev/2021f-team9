using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameSaveOverite : MonoBehaviour
{
    public Button yourButton;

    //Awake is called on instantion
    private void Awake()
    {
    
    }

    //Awake is called once the script is called
    void Start()
    {
        //If the button is clicked go to TaskOnClick()
        yourButton.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
 
    }

    //This overwrites the save file and goes to the Hub
    public void TaskOnClick()
    {
        PlayerPrefs.SetInt("apple", 0);
        PlayerPrefs.SetInt("appleClaimed", 0);
        PlayerPrefs.SetInt("finalcactus", 0);
        PlayerPrefs.SetInt("finalcactusClaimed", 0);
        PlayerPrefs.SetInt("epictome", 0);
        PlayerPrefs.SetInt("epictomeClaimed", 0);
        PlayerPrefs.SetInt("specialskull", 0);
        PlayerPrefs.SetInt("specialskullClaimed", 0);
        PlayerPrefs.SetInt("didYouWin", 0);
        PlayerPrefs.SetInt("didYouWinClaimed", 0);
        File.Delete(Application.persistentDataPath + "\\savedata.heheh");
        SceneManager.LoadScene("Tutorial");
        //SceneManager.LoadScene("Hub");
    }
    
}
