using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressSlider : MonoBehaviour {

    Slider SLI;
    [SerializeField]
    CharacterManager CM;

	// Use this for initialization
	void Start () {
        SLI = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        SLI.maxValue = CM.TimeToComplete;
        SLI.value = CM.ProjectProgress;
	}
}
