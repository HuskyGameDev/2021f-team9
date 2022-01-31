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


    private void Awake()
    {
        save = new Save(saveDataObj);
    }

    void Start()
    {
        yourButton.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
 
    }

    void TaskOnClick()
    {
        save.save();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Hub");
    }
    
}
