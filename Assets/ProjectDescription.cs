using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectDescription : MonoBehaviour {
    [SerializeField]
    Dropdown DRP;
    [SerializeField]
    string[] Descricoes;
    [SerializeField]
    Text TX;


    void Update()
    {
        TX.text = Descricoes[DRP.value];
    }


}
