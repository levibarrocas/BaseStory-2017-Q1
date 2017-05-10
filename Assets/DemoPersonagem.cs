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

	void Update () {
        TX.text = GP.Personagems[slot].Nome(true);
	}
}
