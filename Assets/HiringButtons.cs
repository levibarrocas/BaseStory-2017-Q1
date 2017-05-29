using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiringButtons : MonoBehaviour
{
    [SerializeField]
    bool ShowCharacter;
    [SerializeField]
    int slot;
    Text TX;
    Button BTN;
    
    private void Start()
    {
        BTN = GetComponent<Button>();
        BTN.onClick.AddListener(OnClick);
        TX = GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (HireableManager.HM.Contrataveis.Count >= slot + 1)
        {
            BTN.interactable = true;
            TX.text = HireableManager.HM.Contrataveis[slot].Nome(true);
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
            VisualizadorPersonagem.VP.MostrarPersonagem(HireableManager.HM.Contrataveis[slot],true,slot);
        }
    }
}
