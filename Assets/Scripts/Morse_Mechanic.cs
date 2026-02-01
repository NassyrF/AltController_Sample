using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;

public class Morse_Mechanic : MonoBehaviour
{
    public UnityEvent<string> changeDisplay;
    public int lengthOfMorse;
    private string morseSentence;
    public UnityEvent<string> playerDisplay;
    public UnityEvent morseCorrect;
    public UnityEvent morseIncorrect;
    private List<string> code;
    private List<string> options;
    private List<string> playerMorse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisplayNewCode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Generates a random Morse string of length s_length
    private string generateMorse(int s_length){
        playerMorse = new List<string>();
        code = new List<string>();
        options = new List<string>{"_", "."};

        for (int i = 0; i < s_length; i++){
            code.Add(options[Random.Range(0,2)]);
        }

        return string.Join(" ",code);
    }


    //Changes display in the UI to the new Morse Phrase to match
    public void DisplayNewCode(){
        morseSentence=generateMorse(lengthOfMorse);
        changeDisplay.Invoke(morseSentence);
        playerDisplay.Invoke(" ");
    }


    //Adds the player's input to a list, and if it's the same length as the sample,
    //then it compares the vale=ues using the void under this one (CompareInput)
    public void ReceivePlayerLetter(string letter){

        playerMorse.Add(letter);
        playerDisplay.Invoke(string.Join(" ",playerMorse));
        // print("INPUT SO FAR :"+string.Join(" ",playerMorse));
        // print("playerLen: "+playerMorse.Count.ToString());
        // print("puterLen: "+morseSentence.Length.ToString());

        if(playerMorse.Count==lengthOfMorse){
            CompareInput(string.Join(" ",playerMorse));
        }
    }


    //Compares the values inputted by the player to the Computer's Morse string
    public void CompareInput(string playerSentence){
        if(playerSentence==morseSentence){
            //print("YAYYYY");
            morseCorrect.Invoke();
        }
        else{
            //print("NAURRRRR");
            morseIncorrect.Invoke();
        }
        changeDisplay.Invoke(" ");
        playerDisplay.Invoke(" ");
        StartCoroutine("NewMorseDelay");
    }


    //After two seconds, a new code appears
    private IEnumerator NewMorseDelay(){
        yield return new WaitForSeconds(2f);
        DisplayNewCode();
    }

 
}
