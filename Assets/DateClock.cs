using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateClock : MonoBehaviour {

    Text TX;
    private void Start()
    {
        TX = GetComponent<Text>();
    }

    private void Update()
    {
        TX.text = TimeManager.TM.ClockDate();
    }

}
