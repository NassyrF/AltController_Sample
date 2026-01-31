using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Yarn.Unity;
using TMPro;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private DialogueRunner dialogueRunner;
    public static UnityAction DialogStart, DialogOver;

    public bool dialogReady, dialogStarted;
    public Canvas dialoguePos;
    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
        dialogueRunner = GetComponent<DialogueRunner>();
    }

    // private void OnEnable()
    // {
    //     interactable.onTalk += TalkInteraction;
    //    // DialogOver += GiveItem; 
    //    //^^^^^^^^^^^ DialogOver event doesn't take in itemdata
    // }
   
    // private void OnDisable()
    // {
    //     interactable.onTalk -= TalkInteraction;
       
    //     // DialogOver -= GiveItem;
    //     //^^^^^^^^^^^ DialogOver event doesn't take in itemdata

    // }

    // public void LoadDialog(string node)
    // {
    //     dialogueRunner.startNode = node;
    //     dialogReady = true;
    // }

    public void StartDialog(string startNodeName)
    {
        print("Calling Dialogue Runner");
        dialogueRunner.StartDialogue(startNodeName);

        
        // if (dialogReady && !dialogStarted)
        // {
        //     dialogueRunner.Stop();

        //     dialogueRunner.StartDialogue(startNodeName);
        //     if (DialogStart != null)
        //         DialogStart();

        //     dialogStarted = true;
        // }
    }
    public void OnDialogOver()
    {
        if (DialogStart != null)
            DialogOver();

        dialogStarted = false;

    }

    // public void TalkInteraction(Item itemdata)
    // {
    //     Debug.Log("Talking rn" + itemdata.name);
        
    //     dialoguePos.transform.localPosition = itemdata.diagPos;
    //     LoadDialog(itemdata.node);
    //     StartDialog();
        
    // }

    // public void GiveItem(Item itemdata)
    // {
    //     if(dialogueRunner.VariableStorage.TryGetValue<bool>("giveReward", out var reward))
    //     {
    //         if (reward)
    //         {
    //             InventoryManager.instance.Add(itemdata);
    //         }
    //     }
    // }

}