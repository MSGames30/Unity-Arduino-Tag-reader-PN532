using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Reader : MonoBehaviour
{

    //object serialport to listen usb
    System.IO.Ports.SerialPort Port;

    //variable to check if arduino is connect
    bool IsInit = false;

    public AudioSource sound = null;


    private void Start()
    {
        //Port = new System.IO.Ports.SerialPort();
        //Port.PortName = "COM3";
        //Port.BaudRate = 9600;
        //Port.ReadTimeout = 500;

        //Port.Open();
    }

    private void Update()
    {
        if(!IsInit)
        {
            IsInit = true;
            Port = new System.IO.Ports.SerialPort();
            Port.PortName = "COM3";
            Port.BaudRate = 9600;
            Port.ReadTimeout = 1000;
            Port.DtrEnable = true;

            Port.Open();

            StartCoroutine(IReadTag());
        }
        
        //if(Port.ReadLine() != "")
        //{
            //Debug.Log(Port.ReadLine());
        //}

        //string readLine = Port.ReadLine();
        //if(readLine != "NULL")
        //{
        //    Debug.Log("connecté !!");
        //    sound.Play();
        //}
        //else
        //{
        //    Debug.Log(readLine);
        //}


        //Debug.Log("1");
    }

    IEnumerator IReadTag()
    {
        while(true)
        {

            string readLine = Port.ReadLine();
            if (readLine != "NULL")
            {
                Debug.Log("connecté !!");
                sound.Play();
            }

        }
            yield return null;
    }

}