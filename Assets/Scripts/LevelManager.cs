using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public UnityEvent<string> StarThedialogue;
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
