using UnityEngine;
using UnityEngine.Events;
using System; 

[Serializable]
public class StringUnityEvent : UnityEvent<string> { }
public class LevelManager : MonoBehaviour
{
    public StringUnityEvent StarThedialogue;
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
        
    }

    public void dialogueOver(){

        if (gameState==0) {
            gameState+=1;
        }
        else if(gameState==2){
            gameState+=1;
        }
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

    
}
