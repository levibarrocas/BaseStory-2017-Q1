using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizadorPersonagem : MonoBehaviour {
    [SerializeField]
    Text Nome;
    [SerializeField]
    Text Profissao;
    [SerializeField]
    Text Habilidade1;
    [SerializeField]
    Text Habilidade2;
    [SerializeField]
    Text Habilidade3;
    [SerializeField]
    Text Habilidade4;
    [SerializeField]
    Text Salario;
    [SerializeField]
    GameObject Panel;
    [SerializeField]
    Text Level;
    [SerializeField]
    Button HireButton;
    [SerializeField]
    Text HireText;
    [SerializeField]
    Button SalaryButton;
    [SerializeField]
    Text SalaryText;
    [SerializeField]
    Image CharacterAvatar;


    Personagem ActiveCharacter;

    int slot;

    public static VisualizadorPersonagem VP;

    public void Awake()
    {
        if(VP == null)
        {
            VP = this;
           Panel.SetActive(false);
        } else if (VP != this)
        {
            Destroy(gameObject);
        }
    }


    public void MostrarPersonagem(Personagem PER)
    {
        ActiveCharacter = PER;
        Panel.SetActive(true);
        Nome.text = PER.Nome(true);
        Profissao.text = PER.Profisao.Classe;
        Habilidade1.text = PER.Habilidade1.ToString();
        Habilidade2.text = PER.Habilidade2.ToString();
        Habilidade3.text = PER.Habilidade3.ToString();
        Habilidade4.text = PER.Habilidade4.ToString();
        Level.text = "Level: " + PER.Level;
        Salario.text = Mathf.Round(PER.Salario).ToString();

        if (PER.Sexo) {
            CharacterAvatar.sprite = GeradorPersonagem.GP.PersonagemMasculinos[PER.ImageIndex];
        } else
        {
            CharacterAvatar.sprite = GeradorPersonagem.GP.PersonagemFemininos[PER.ImageIndex];
        }
      
        HireButton.gameObject.SetActive(false);
        SalaryButton.gameObject.SetActive(false);

    }

    public void MostrarPersonagem(int Slot)
    {
        MostrarPersonagem(CharacterManager.CM.Funcionarios[Slot]);
    }
    public void MostrarPersonagem(Personagem PER,bool Hire,int Slot)
    {
        if (Hire)
        {
            MostrarPersonagem(PER);
            HireButton.gameObject.SetActive(true);
            HireText.text = "Contratar por " + PER.Salario / 2 + " reais";
            slot = Slot;
        } else
        {
            MostrarPersonagem(PER);
            slot = Slot;
            SalaryButton.gameObject.SetActive(true);
            SalaryText.text = "Pagar o salario de " + PER.Salario + " reais";
        }
    }

    public void HireCharacter()
    {
        if(CurrencyManager.CM.Reais.Spend((int)HireableManager.HM.Contrataveis[slot].Salario / 2,false))
        {
            CharacterManager.CM.Funcionarios.Add(HireableManager.HM.Contrataveis[slot]);
            Notification NOT = new Notification("Contrato!", "Você contratou " + HireableManager.HM.Contrataveis[slot].Nome(true) + ".Ele foi adcionado a sua equipe");
            NotificationSystem.NS.ShowNotification(NOT);
            HireableManager.HM.Contrataveis.RemoveAt(slot);
        } else
        {
            Notification NOT = new Notification("Contrato!", "Você não tem dinheiro o suficiente para contratar " + HireableManager.HM.Contrataveis[slot].Nome(true) + ".");
            NotificationSystem.NS.ShowNotification(NOT);
        }
    }

    public void PaySalary()
    {
        if (ActiveCharacter.WaitingToBePaid) {
            if (CurrencyManager.CM.Reais.Spend((int)ActiveCharacter.Salario)){
                ActiveCharacter.WaitingToBePaid = false;
                ActiveCharacter.LastPayment = TimeManager.TM.IntDate();
                Notification NOT = new Notification("Salario", "Você pagou o salario de " + ActiveCharacter.Nome(true));
                NotificationSystem.NS.ShowNotification(NOT);
            } else
            {
                Notification NOT = new Notification("Erro!", "Você não tem o dinheiro nescessario para pagar o salario de " + ActiveCharacter.Nome(true));
                NotificationSystem.NS.ShowNotification(NOT);
            }
        } else
        {
            Notification NOT = new Notification("Erro!", "É muito cedo pra pagar o salario de " + ActiveCharacter.Nome(true));
            NotificationSystem.NS.ShowNotification(NOT);

        }
    }
}
