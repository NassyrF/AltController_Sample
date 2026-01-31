using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Morse_Mechanic : MonoBehaviour
{
    public UnityEvent<string> changeDisplay;
    public int lengthOfMorse;
    private List<string> code;
    private List<string> options;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print(generateMorse(3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayNewCode(){
        changeDisplay.Invoke(generateMorse(lengthOfMorse));
    }

 
    private string generateMorse(int s_length){

        code = new List<string>();
        options = new List<string>{"_", "."};

        for (int i = 0; i < s_length; i++){
            code.Add(options[Random.Range(0,2)]);
        }

        return string.Join(" ",code);

    }
}
