using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerCharacter : MonoBehaviour
{
    TalkingToNPCScript npcScript;

    public GameObject wagon;

    public DialogueBranch branchToUseWhenAllCompleted;
    public GameObject TutorialBarrier;

    int index = -1;

    // Start is called before the first frame update
    void Start()
    {
        npcScript = GetComponent<TalkingToNPCScript>();

        //EventManager.eventInstance.onQuestComplete += ChangeQuest;
    }

    public void WeaponFound()
    {
        npcScript.enabled = true;
    }

    public int CurrentIndex()
    {
        return index;
    }
}

//[System.Serializable]
//public class AssignedQuest
//{
//    public DialogueBranch startBranch;
//    public DialogueBranch notCompleteBranch;
//    public DialogueBranch completeBranch;
//    public string QuestType;
//    public QuestSO Quest;
//    public CraftingRecipe tempRecipe;
//    public InteractionScript interaction;
//    public ItemObject itemToUse;
//    public Enemy enemy;
//    public InventSlotScript slot;
//    public Sprite[] questObjectiveSprites;
//    public bool showCompleteScreen;
//    public bool endImmediatlyUponCompletion;
//}
