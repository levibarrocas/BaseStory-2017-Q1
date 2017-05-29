using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartProjectButton : MonoBehaviour {

    Button BTN;
    [SerializeField]
    InputField INP;
    [SerializeField]
    Dropdown DRP;
    [SerializeField]
    int Slot = 200;
	// Use this for initialization
	void Start () {
        BTN = GetComponent<Button>();
        BTN.onClick.AddListener(OnClick);
	}
	
    public void SetSlot(int I)
    {
        Slot = I;
    }

    void OnClick()
    {
        ProjectManager.PM.StartProject(INP.text, Slot, DRP.value);
    }
}
