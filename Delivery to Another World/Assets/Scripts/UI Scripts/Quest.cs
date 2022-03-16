using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questName;
    public bool isNewQuest = true;
    public string objective;
    public string questArea;
    public string treasure;

    [SerializeField] private bool isComplete = false;
    private bool isClaimed = false;

    public Dialogue dialogue;
    public Dialogue completionDialogue;

    public void CompleteQuest()
    {
        isComplete = true;
    }

    public void ClaimQuestReward()
    {
        isClaimed = true;
    }

    public bool isQuestClaimed()
    {
        return isClaimed;
    }

    public bool isQuestComplete()
    {
        return isComplete;
    }
}
