using UnityEngine;
using TMPro;

public class DisplayPlayerMorse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayMe(string texter)
    {
        this.GetComponent<TMP_Text>().text=texter;
        
            }
}
