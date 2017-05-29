using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoTeam : MonoBehaviour
{
    [SerializeField]
    bool ShowCharacter;
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
        if (CharacterManager.CM.Funcionarios.Count >= slot + 1)
        {
            BTN.interactable = true;
            TX.text = CM.Funcionarios[slot].Nome(true);
        }
        else
        {
            TX.text = "Slot Vazio";
            BTN.interactable = false;
        }
    }

    void OnClick()
    {
        if (ShowCharacter)
        {
            VP.MostrarPersonagem(CM.Funcionarios[slot]);
        }
    }
}