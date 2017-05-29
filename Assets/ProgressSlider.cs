using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressSlider : MonoBehaviour {

    Slider SLI;

	// Use this for initialization
	void Start () {
        SLI = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        SLI.maxValue = ProjectManager.PM.TimeToComplete;
        SLI.value = ProjectManager.PM.ProjectProgress;
	}
}
