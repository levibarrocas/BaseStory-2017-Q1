using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CurrencyDisplayu : MonoBehaviour {

    [SerializeField]
    string Currency;
    Text TX;

    private void Start()
    {
        TX = GetComponent<Text>();
    }

    private void Update()
    {
        if(Currency == "Real")
        {
            TX.text = CurrencyManager.CM.Reais.Money().ToString();
        }
        if (Currency == "Reputacao")
        {
            TX.text = CurrencyManager.CM.Reputacao.Money().ToString();
        }
    }

}
