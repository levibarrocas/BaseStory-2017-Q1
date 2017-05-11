using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartProjectButton : MonoBehaviour {

    Button BTN;
    [SerializeField]
    InputField INP;
    [SerializeField]
    CharacterManager CM;
	// Use this for initialization
	void Start () {
        BTN = GetComponent<Button>();
        BTN.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnClick()
    {
        CM.StartProject(INP.text);
    }
}
