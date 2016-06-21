using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DigitalCountdown : MonoBehaviour {
	private Text textClock;

	private float countdownTimerDuration;
	private float countdownTimerStartTime;

	// Use this for initialization
	void Start () {
		textClock = GetComponent<Text>();

		CountdownTimerReset (30);
	}
	
	// Update is called once per frame
	void Update () {
		//Default, saying 'we done', unless that is not the case.
		string timerMessage = "Countdown has finished";

		//I assume this is some sort of 'casting' of the return? Like type conversion?
		int timeLeft = (int)CountdownTimerSecondsRemaining();

		//Basic conditional
		if (timeLeft > 0) {
			//If there is time left, reset the timerMessage to read what time is left,
			//Processing the TimeLeft with the Leading Zero function to get 'nice' looking information.
			timerMessage = "Countdown Seconds Remaining: " + LeadingZero (timeLeft);
		}

		//Update the actual text of the GUI element to reflect the message from the logic.
		textClock.text = timerMessage;
	}

	private void CountdownTimerReset (float delayInSeconds) {
		//Spin up a new timer, then capture the current system time so we can track the change in time.
		countdownTimerDuration = delayInSeconds;
		countdownTimerStartTime = Time.time;
	}

	private float CountdownTimerSecondsRemaining () {
		//Grab the current system time, and find the difference between that and when we started ("StartTime")
		float elapsedSeconds = Time.time - countdownTimerStartTime;
		//Check the difference between the Time Duration and the observed Delta noted above
		float timeLeft = countdownTimerDuration - elapsedSeconds;
		return timeLeft;
	}

	private string LeadingZero(int n){
		return n.ToString ().PadLeft (2, '0');
	}
}