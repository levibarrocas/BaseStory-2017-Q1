using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HireHotbar : MonoBehaviour
{
    [SerializeField]
    bool ShowCharacter;
    [SerializeField]
    int slot;
    Text TX;
    Button BTN;
    [SerializeField]
    Image IMG;
    [SerializeField]
    Color Transparent;
    [SerializeField]
    Color Solid;

    private void Start()
    {
        BTN = GetComponent<Button>();
        BTN.onClick.AddListener(OnClick);
        TX = GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (CharacterManager.CM.Funcionarios.Count >= slot + 1)
        {
            BTN.interactable = true;
            if (CharacterManager.CM.Funcionarios[slot].Sexo == true)
            {
                IMG.sprite = GeradorPersonagem.GP.PersonagemMasculinos[CharacterManager.CM.Funcionarios[slot].ImageIndex];
            }
            else
            {
                IMG.sprite = GeradorPersonagem.GP.PersonagemFemininos[CharacterManager.CM.Funcionarios[slot].ImageIndex];
            }
            IMG.color = Solid;
            TX.text = "";
        }
        else
        {
            TX.text = "Slot Vazio";
            IMG.color = Transparent;
            BTN.interactable = false;
        }
    }

    void OnClick()
    {
        if (ShowCharacter)
        {
           VisualizadorPersonagem.VP.MostrarPersonagem(CharacterManager.CM.Funcionarios[slot],false,slot);
        }
    }
}

