using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour {
    [SerializeField]
    public Currency Reais;
    [SerializeField]
    public Currency Reputacao;
    [SerializeField]
    public Currency Reflorestamento;
    public static CurrencyManager CM;

    private void Awake()
    {
        if (CM == null)
        {
            CM = this;
        }
        else if (CM != this)
        {
            Destroy(gameObject);
        }
    }

    public void Cheat(int i)
    {
        if(i == 0)
        {
            Reais.Gain(10000); Notification NOT = new Notification("Cheats!", "Você usou cheats para ganhar 1000 reais!");
            NotificationSystem.NS.ShowNotification(NOT);
        }
        else if (i == 1)
        {
            Reputacao.Gain(10000);
            Notification NOT = new Notification("Cheats!", "Você usou cheats para ganhar 1000 pontos de reputacao!");
            NotificationSystem.NS.ShowNotification(NOT);
        }
        else if (i == 2)
        {
            Reflorestamento.Gain(10000);
            Notification NOT = new Notification("Cheats!", "Você usou cheats para ganhar 1000 pontos de reflorestamento!");
            NotificationSystem.NS.ShowNotification(NOT);
        }


    }

}

[System.Serializable]
public class Currency
{
    public string SingleName;
    public string PluralName;

    float Value;

    public void Gain(int Ammount)
    {
        Value += Ammount;
    }
    public bool Spend(int Ammount)
    {
        if(Value >= Ammount)
        {
            Value -= Ammount;
            return true;
        } else
        {
            Notification NOT = new Notification("Warning!", "You don't have enough " + PluralName + "for this transaction");
            NotificationSystem.NS.ShowNotification(NOT);
            return false;
        }
    }

    public bool Spend(int Ammount,bool notification)
    {
        if (Value >= Ammount)
        {
            Value -= Ammount;
            return true;
        }
        else if(notification)
        {
            return false;
        } else
        {
            Notification NOT = new Notification("Warning!", "Você " + PluralName + "não tem o suficiente pra esta transação");
            NotificationSystem.NS.ShowNotification(NOT);
            return false;
        }
    }

    public int Money()
    {
        return (int)Value;
    }

}
