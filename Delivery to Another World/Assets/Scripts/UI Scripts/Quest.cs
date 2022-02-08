using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string name;
    public bool isNewQuest = true;
    public string objective;

    private bool isComplete = false;
    private bool isClaimed = false;

    [TextArea(3, 10)]
    public string[] scentences;

    public void CompleteQuest()
    {
        isComplete = true;
    }

    public void ClaimQuestReward()
    {
        isClaimed = true;
    }

    public bool isQuestComplete()
    {
        return isComplete;
    }
}
