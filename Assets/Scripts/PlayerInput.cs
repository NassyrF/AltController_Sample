using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private bool keyDown;
    private float keyPressTime;
    public float desiredTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keyPressTime=0;
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
            Debug.Log(keyPressTime);
            keyPressTime=0;
        }
        else{
            keyDown=true;
        }
    }
}
