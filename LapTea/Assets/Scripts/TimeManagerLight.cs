using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManagerLight : MonoBehaviour {

    // Minutes and Seconds
    private int _minutes;
    private int _seconds;

    private Text _thisText;
    private float timeLeft;

    // Get hold of the Canvas reference 
    public Canvas MainMenuLayout;
    public Canvas LightTeaLayout;
    public Canvas BlackTeaLayout;
    public Canvas TisaneTeaLayout;


    //Gettting the ButtonManager script reference 
    public GameObject MenuManager;
    private ButtonManager mng;



    // Grab the object text
	private void Awake()
	{
        _thisText = GetComponent<Text>();
        mng = MenuManager.GetComponent<ButtonManager>();
	}

    // Gran initial time 
    public void OnEnable()
	{
        timeLeft = GetInitialTime();
        _minutes = GetLeftMinutes();
        _seconds = GetLeftSeconds();
    }

    // Time countdown and time checker 
    private void Update()
	{
        
        Timer();
	}

    // return initial time 
    private float GetInitialTime()
    {
        int minutes = 2;
        int seconds = 30;
        return (minutes *60f) +seconds;
    }

    // get minutes 
    private int GetLeftMinutes()
    {
        return Mathf.FloorToInt(timeLeft/60f);
    }

    // get seconds 
    private int GetLeftSeconds()
    {
        return Mathf.FloorToInt(timeLeft % 60);
    }

    // check time status (print if there is time left / main menu once time over)
    private void Timer()
    {
        if(timeLeft>0f)
        {
             timeLeft = timeLeft - Time.deltaTime;
            _minutes = GetLeftMinutes();
            _seconds = GetLeftSeconds();
            _thisText.text = _minutes + ":" + _seconds.ToString("00");
        }
        else
        {
            MainMenuLayout.gameObject.SetActive(true);
            LightTeaLayout.gameObject.SetActive(false);
            BlackTeaLayout.gameObject.SetActive(false);
            TisaneTeaLayout.gameObject.SetActive(false);
            mng.myPort.Write("0"); // weiting 0 signal for the stepper motor 

        }
    }
}
