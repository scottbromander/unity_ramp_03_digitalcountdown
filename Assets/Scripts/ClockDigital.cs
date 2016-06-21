using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System;

public class ClockDigital : MonoBehaviour {

	private Text textClock;

	// Use this for initialization
	void Start () {
		textClock = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		DateTime time = DateTime.Now;
		string hour = LeadingZero (time.Hour);
		string minute = LeadingZero (time.Minute);
		string second = LeadingZero (time.Second);

		textClock.text = hour + ':' + minute + ':' + second;
	}

	string LeadingZero(int n){
		return n.ToString ().PadLeft (2, '0');
	}	
}
