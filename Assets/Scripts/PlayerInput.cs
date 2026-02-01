using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using UnityEngine.InputSystem;
using System;
using UnityEngine.UI;
using System.ComponentModel;

public class PlayerInput : MonoBehaviour
{
    public Canvas pauseCanvas; 
    public static PlayerInput Instance;
    public static event Action Pause;

    private bool keyDown;
    private float keyPressTime;
    public float desiredTime;
    //private List<string> playerPhrase;
    public UnityEvent<string> playerLetter;

    private UnityEngine.InputSystem.PlayerInput playerInput; // fully qualified
    private InputActionAsset inputActions;
    private bool paused;

    public UnityEvent interrupt;


     private void Awake()
    {
        Instance = this;
        playerInput = GetComponent<UnityEngine.InputSystem.PlayerInput>();
        inputActions = playerInput.actions;
    }
    
     private void OnEnable()
    {
        if (inputActions != null)
        {
            inputActions.Enable();
            inputActions["esc"].performed += Pause_Action;
        }
    }

    private void OnDisable()
    {
        if (inputActions != null)
        {
            inputActions.Disable(); // was "disabled()" — not a valid method
            inputActions["esc"].performed -= Pause_Action;
        }
    }

     private void Pause_Action(InputAction.CallbackContext context)
    {
        print("PAUSED GAME");
        if (!paused)
        {
            paused = true;
            //make canvas active
            pauseCanvas.gameObject.SetActive(true);
        }
        else
        {
            paused = false;
            pauseCanvas.gameObject.SetActive(false);
        }

    }

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



    public void theButton(){
        if(keyDown){
            interrupt.Invoke();
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
                SoundManager.Instance.MorseNoise("dash");
                print("dash");
            }
            else{
                //playerPhrase.Add(".");
                playerLetter.Invoke(".");
                SoundManager.Instance.MorseNoise("dot");
                 print("dot");
            }

            keyPressTime=0;

    }
}
