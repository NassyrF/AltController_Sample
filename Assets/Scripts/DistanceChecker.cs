using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public bool closer;
    public bool further;

    private int distanceCovered = 0;

    private int lastLocation = 0;
    private int currentLocation = 0;

    public static DistanceChecker instance;
    public void Awake()
    {
        DistanceChecker.instance = this;
    }

    public void check(int distance)
    {
        //gets input from sensor
        lastLocation = currentLocation;
        currentLocation = distance;
        distanceCovered = lastLocation - currentLocation;
        Determine(distanceCovered);
    }

    private void Determine(int dist)
    {
        if(dist > 10)
        {
            print("MOVED FORWARD");
            // closer = true;
            // further = false;
        }
        else if(dist < -10)
        {
            print("MOVED BACKWARD");
            // closer = false;
            // further = true;
        }

    }

}
