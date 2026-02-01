using UnityEngine;
using UnityEngine.Events;
using System; 

[Serializable]
public class StringUnityEvent : UnityEvent<string> { }
public class LevelManager : MonoBehaviour
{
    public StringUnityEvent StarThedialogue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StarThedialogue.Invoke("Tuto1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
