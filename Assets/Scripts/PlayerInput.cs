using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class PlayerInput : MonoBehaviour
{
    private bool keyDown;
    private float keyPressTime;
    public float desiredTime;
    //private List<string> playerPhrase;
    public UnityEvent<string> playerLetter;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keyPressTime=0;
        //playerPhrase = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if(keyDown){
            keyPressTime+=Time.deltaTime;
        }
    }



    public void OnInteract(){
        if(keyDown){
            keyDown=false;
            constructSentence();
        }
        else{
            keyDown=true;
        }
    }

    private void constructSentence(){

        Debug.Log(keyPressTime);

            if(keyPressTime>=desiredTime){
                //playerPhrase.Add("_");
                playerLetter.Invoke("_");
            }
            else{
                //playerPhrase.Add(".");
                playerLetter.Invoke(".");
            }

            keyPressTime=0;

    }
}
