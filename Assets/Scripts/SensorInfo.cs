using UnityEngine;
using System.IO.Ports;

public class SensorInfo : MonoBehaviour
{
    SerialPort serial = new SerialPort("/dev/cu.usbmodem2101", 9600);
    public string received_string;
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
            Debug.Log(string.Join(", ", datas));
        }
    }
    catch (System.TimeoutException)
    {
        // no data this frame, just wait for next one
    }
    catch (System.Exception e)
    {
        Debug.LogError("Serial read error: " + e.Message);
    }
}
}
