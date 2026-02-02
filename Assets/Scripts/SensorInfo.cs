using UnityEngine;
using System.IO.Ports;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.IO.Pipes;
using System.Collections.Generic; 

public class SensorInfo : MonoBehaviour
{
    SerialPort serial = new SerialPort("/dev/cu.usbmodem2101", 9600);
    public string received_string;

    public static int distance;
    public static int buttonNum;

    List<int> distanceList = new List<int>();
    [Range(0,100)] public int distanceListLength = 50;
    public static int average = 0;


    public string[] datas;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        serial.Open();
        //the time it’ll wait to read
        serial.ReadTimeout = 50;
    }
void Update()
{
    try
    {
        if (serial.BytesToRead > 0)
        {
            received_string = serial.ReadLine();
            string[] datas = received_string.Split(',');
            int.TryParse(datas[0], out buttonNum);
            int.TryParse(datas[1], out distance);

            //print(buttonNum);
            //print(distance);
            measureDistance(distance);
        }
    }
    catch (System.TimeoutException)
    {
        // no data this frame, just wait for next one
    }
    catch (System.Exception e)
    {
        //UnityEngine.Debug.LogError("Serial read error: " + e.Message);
    }
}

    private void measureDistance(int Distance)
    {
        if(distanceList.Count < distanceListLength)
        {
            distanceList.Add(Distance);
        }
        else
        {
            //if list too long average them and send off the value, then reset the list
            foreach (int num in distanceList)
            {
                average = average + num;
            }
            average = average/distanceListLength;
            print("the average is " + average);
            DistanceChecker.instance.check(average);
            distanceList = new List<int>();
        }
       
    }


}
