using UnityEngine;
using UnityEngine.Events;
using System; 

[Serializable]
public class StringUnityEvent : UnityEvent<string> { }
public class LevelManager : MonoBehaviour
{
    public StringUnityEvent StarThedialogue;
    public UnityEvent<int> NewMorse;
    public GameObject morseUI;
    public GameObject speechUI;
    private int gameState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameState=0;
        StarThedialogue.Invoke("Tuto1");
    }

    // Update is called once per frame
    void Update()
    {
        //print(gameState);
    }

    public void dialogueOver(){

        switch(gameState){
            case 0 :
                gameState+=1;
                break;
            case 2 :
                gameState+=1;
                break;
            case 4 :
                morseUI.SetActive(true);
                speechUI.SetActive(true);
                NewMorse.Invoke(5);
                gameState+=1;
                break;
            case 5 :
                morseUI.SetActive(true);
                speechUI.SetActive(true);
                NewMorse.Invoke(5);
                break;
        }
            
        // if (gameState==0) {
        //     gameState+=1;
        // }
        // else if(gameState==2){
        //     gameState+=1;
        // }
        // else if(gameState==4){
        //     morseUI.SetActive(true);
        //     gameState+=1;
        // }
    }

    public void WentBack(){
        if(gameState==1){
            gameState+=1;
            StarThedialogue.Invoke("TooFar1");
        }
    }

    public void WentForward(){
        if(gameState==3){
            gameState+=1;
            StarThedialogue.Invoke("Tuto2");
        }
    }

    public void morseCorrect(){
        if(gameState==5){
            morseUI.SetActive(false);
            HandAnimator.instance.triggerHands(false);
            gameState+=1;
            StarThedialogue.Invoke("Tuto4");
        }
    }

    public void morseIncorrect(){
        if(gameState==5){
            morseUI.SetActive(false);
            HandAnimator.instance.triggerHands(false);
            StarThedialogue.Invoke("Tuto3a");
    }
    }

    
}
