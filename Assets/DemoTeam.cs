using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoTeam : MonoBehaviour
{
    [SerializeField]
    int slot;
    [SerializeField]
    Text TX;
    Button BTN;
    [SerializeField]
    VisualizadorPersonagem VP;
    [SerializeField]
    CharacterManager CM;

    private void Start()
    {
        BTN = GetComponent<Button>();
        BTN.onClick.AddListener(OnClick);
    }

    void Update()
    {
        if (CM.Funcionarios.Count >= slot + 1)
        {
            TX.text = CM.Funcionarios[slot].Nome(true);
        }
        else
        {
            TX.text = "Vazio";
        }
    }

    void OnClick()
    {
        VP.MostrarPersonagem(CM.Funcionarios[slot]);
    }
}