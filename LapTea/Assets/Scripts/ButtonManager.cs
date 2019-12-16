using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class ButtonManager : MonoBehaviour {

    // Grab each Canvas components
    public Canvas MainMenuLayout;
    public Canvas LightTeaLayout;
    public Canvas BlackTeaLayout;
    public Canvas TisaneTeaLayout;

    //Serial Port
    public SerialPort myPort = new SerialPort("/dev/cu.usbmodem1421", 9600);

    // only the main menu is active at the beginning 
	public void Awake()
	{
        MainMenuLayout.gameObject.SetActive(true);
        LightTeaLayout.gameObject.SetActive(false);
        BlackTeaLayout.gameObject.SetActive(false);
        TisaneTeaLayout.gameObject.SetActive(false);

        if (myPort.IsOpen == false) // open the serial port 
        {
            myPort.Open();
        }
     
      
    }



	//Activate Main Menu Layout
	public void ActivateMainMenuCanvas()
    {
        MainMenuLayout.gameObject.SetActive(true);
        LightTeaLayout.gameObject.SetActive(false);
        BlackTeaLayout.gameObject.SetActive(false);
        TisaneTeaLayout.gameObject.SetActive(false);
        myPort.Write("0"); // write 0 signal for the stepper motor
        Debug.Log("Write 0");

    }

    //Activate Light/Green Tea Canvas
    public void ActivateLightGreenTeaCanvas()
    {
        MainMenuLayout.gameObject.SetActive(false);
        LightTeaLayout.gameObject.SetActive(true);
        BlackTeaLayout.gameObject.SetActive(false);
        TisaneTeaLayout.gameObject.SetActive(false);
        myPort.Write("1"); // write 1 signal for the stepper motor
        Debug.Log("Write 1");

    }

    //Activate Black Tea Canvas
    public void ActivateBlackTeaCanvas()
    {
        MainMenuLayout.gameObject.SetActive(false);
        LightTeaLayout.gameObject.SetActive(false);
        BlackTeaLayout.gameObject.SetActive(true);
        TisaneTeaLayout.gameObject.SetActive(false);
        myPort.Write("1");// write 1 signal for the stepper motor
        Debug.Log("Write 1");

    }

    //Activate Tisane Tea Canvas
    public void ActivateTisaneTeaCanvas()
    {
        MainMenuLayout.gameObject.SetActive(false);
        LightTeaLayout.gameObject.SetActive(false);
        BlackTeaLayout.gameObject.SetActive(false);
        TisaneTeaLayout.gameObject.SetActive(true);
        myPort.Write("1");// write 1 signal for the stepper motor
        Debug.Log("Write 1");

    }

 
}
