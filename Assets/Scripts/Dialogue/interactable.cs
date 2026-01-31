using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

using UnityEngine.UIElements;
using System.Collections;
using Cursor = UnityEngine.Cursor;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class interactable : MonoBehaviour
{
    public delegate void HandleItem(Item item); // <-- add this
    public static event HandleItem onTalk;

    public Item item;


    public void Interact()
    {
        switch (gameObject.tag)
        {
            case "canTalk":
            {
                // //first finds if there's an outline and will disable it 
                // if (gameObject.transform.GetComponent<Outline>())
                // {
                //     gameObject.transform.GetComponent<Outline>().enabled = false;
                // }

                    onTalk?.Invoke(item); //called in DialogueManager
                
                    break;
            }


            break;
        }
    }
}

    
    

       

    
