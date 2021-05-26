using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScorm : MonoBehaviour
{
    private float startTime;
    private float currentTime;

    public AudioSource Button;

    public GameObject Counter;

    public int vergleich;
    // Start is called before the first frame update
    	void Awake () {
		startTime = Time.time;
	}



	/// <summary>Fires on Object's Unity3D Update event, calculate and display the current time in the timer GUI element.</summary>
	void Update () {
        vergleich = CompareCounter.counter;
		currentTime = Time.time - startTime;
		//TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
		//TextTimer.GetComponent<Text>().text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
	}

    // Update is called once per frame


    public void ButtonExitSCORMPressed(){
        ScormManager.SetScoreScaled(vergleich);
        ScormManager.SetSessionTime(currentTime);
        ScormManager.SetExit(StudentRecord.ExitType.normal);
        ScormManager.Commit();
        Button.Play();
        Application.Quit();
    }

    public void MenuButtonExitSCORMPressed(){
        //ScormManager.SetScoreScaled(vergleich);
        ScormManager.SetSessionTime(currentTime);
        ScormManager.SetExit(StudentRecord.ExitType.normal);
        ScormManager.Commit();
        Button.Play();
        Application.Quit();
    }
}
