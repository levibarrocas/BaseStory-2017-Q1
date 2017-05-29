using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DemoPersonagem : MonoBehaviour {
    [SerializeField]
    int slot;
    [SerializeField]
    GeradorPersonagem GP;
    [SerializeField]
    Text TX;
    Button BTN;
    [SerializeField]
    VisualizadorPersonagem VP;

    private void Start()
    {
        BTN = GetComponent<Button>();
        BTN.onClick.AddListener(OnClick);
    }

    void Update () {
        TX.text = GP.Personagems[slot].Nome(true);
	}

    void OnClick()
    {
        VP.MostrarPersonagem(GP.Personagems[slot]);
    }
}
