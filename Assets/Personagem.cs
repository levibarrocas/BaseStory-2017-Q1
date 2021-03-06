﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Personagem : System.Object{

    public string NomeP;
	public string Sobrenome;

    // Pesquisa em Campo
    public float Habilidade1;
    // Pesquisa Teorica
    public float Habilidade2;
    // Marketing
    public float Habilidade3;
    // Lider
    public float Habilidade4;

    public float Salario;

    public float Level;

    public float Satisfacao;

    public int LastPayment;

    public int XP;
    public int NextXP = 1000;
    public ProfissaoPersonagem Profisao;
	
	// True para homem e false para mulher
	public bool Sexo;
	
	public int CorDoCabelo;
	public int CorDaPele;
	public int Camisa;
	public int Calca;

    public float Velocidade;
    public float Progresso;

    public int ImageIndex;

    public bool WaitingToBePaid;

	public string Nome(bool LastName){
		if(LastName){
			return NomeP + " " + Sobrenome;
		} else {
			return NomeP;
		}
	}

    public void LevelUp(bool Notification)
    {
        Habilidade1 += Profisao.RatioHab1 * Random.Range(1f, 2f);
        Habilidade2 += Profisao.RatioHab2 * Random.Range(1f, 2f);
        Habilidade3 += Profisao.RatioHab3 * Random.Range(1f, 2f);
        Habilidade4 += Profisao.RatioHab4 * Random.Range(1f, 2f);

        if (Profisao.RatioHab1 > Profisao.RatioHab2 && Profisao.RatioHab1 > Profisao.RatioHab3 && Profisao.RatioHab1 > Profisao.RatioHab4)
        {
            Salario *= Profisao.RatioHab1;
        }
        else if (Profisao.RatioHab2 > Profisao.RatioHab1 && Profisao.RatioHab2 > Profisao.RatioHab3 && Profisao.RatioHab2 > Profisao.RatioHab4)
        {
            Salario *= Profisao.RatioHab2;
        }
        else if (Profisao.RatioHab3 > Profisao.RatioHab1 && Profisao.RatioHab3 > Profisao.RatioHab2 && Profisao.RatioHab3 > Profisao.RatioHab4)
        {
            Salario *= Profisao.RatioHab3;
        }
        else
        {
            Salario *= Profisao.RatioHab4;
        }
        if (Notification)
        {
            if (Sexo)
            {
                Notification NOT = new Notification("Level Up!", NomeP + " " + Sobrenome + "level went up! /n" + "He is level " + Level + " now");
                NotificationSystem.NS.ShowNotification(NOT);
            }
            else
            {
                Notification NOT = new Notification("Level Up!", NomeP + " " + Sobrenome + "level went up! /n" + "He is level " + Level + " now");
                NotificationSystem.NS.ShowNotification(NOT);
            }
        }
        Habilidade1 = Mathf.Round(Habilidade1);
        Habilidade2 = Mathf.Round(Habilidade2);
        Habilidade3 = Mathf.Round(Habilidade3);
        Habilidade4 = Mathf.Round(Habilidade4);
        Salario = Mathf.Round(Salario);

        Level++;
    }

    public void Work(int Slot)
    {
        Progresso += Time.deltaTime;
        if(Progresso > Velocidade)
        {
            ProjectManager.PM.AddProgress((int)Habilidade1, (int)Habilidade2, (int)Habilidade3, Slot);
            Progresso = 0;
        }
    }

    public void LevelUp()
    {
        Habilidade1 += Profisao.RatioHab1 * Random.Range(1f,2f);
        Habilidade2 += Profisao.RatioHab2 * Random.Range(1f,2f); 
        Habilidade3 += Profisao.RatioHab3 * Random.Range(1f,2f); 
        Habilidade4 += Profisao.RatioHab4 * Random.Range(1f,2f);

        if (Profisao.RatioHab1 > Profisao.RatioHab2 && Profisao.RatioHab1 > Profisao.RatioHab3 && Profisao.RatioHab1 > Profisao.RatioHab4)
        {
            Salario *= Profisao.RatioHab1;
        }
        else if (Profisao.RatioHab2 > Profisao.RatioHab1 && Profisao.RatioHab2 > Profisao.RatioHab3 && Profisao.RatioHab2 > Profisao.RatioHab4)
        {
            Salario *= Profisao.RatioHab2;
        }
        else if (Profisao.RatioHab3 > Profisao.RatioHab1 && Profisao.RatioHab3 > Profisao.RatioHab2 && Profisao.RatioHab3 > Profisao.RatioHab4)
        {
            Salario *= Profisao.RatioHab3;
        }
        else
        {
            Salario *= Profisao.RatioHab4;
        }
        if (Sexo) {
            Notification NOT = new Notification("Level Up!", NomeP + " " + Sobrenome + "level went up! /n" + "He is level " + Level + " now");
            NotificationSystem.NS.ShowNotification(NOT);
        }
        else
        {
            Notification NOT = new Notification("Level Up!", NomeP + " " + Sobrenome + "level went up! /n" + "He is level " + Level + " now");
            NotificationSystem.NS.ShowNotification(NOT);
        }
        Habilidade1 = Mathf.Round(Habilidade1);
        Habilidade2 = Mathf.Round(Habilidade2);
        Habilidade3 = Mathf.Round(Habilidade3);
        Habilidade4 = Mathf.Round(Habilidade4);
        Salario = Mathf.Round(Salario);

        Level++;
    }

    public void PassTime()
    {
        
        if(LastPayment < TimeManager.TM.IntDate() - 32)
        {
            Satisfacao -= Random.Range(0, 4);
            WaitingToBePaid = true;
        }
    }

    public void GainXP(int Ammount)
    {
        XP += Ammount;
        if(NextXP < XP)
        {
            LevelUp();
            NextXP *= 4;
        }
    }

    public void BePaid()
    {
        if (CurrencyManager.CM.Reais.Spend((int)Salario))
        {
            LastPayment = TimeManager.TM.IntDate();
        }
    }

}
[System.Serializable]
public class ProfissaoPersonagem : System.Object
{

    public string Classe;

    public int MinHab1;
    public int MaxHab1;
    public int MinHab2;
    public int MaxHab2;
    public int MinHab3;
    public int MaxHab3;
    public int MinHab4;
    public int MaxHab4;

    public int MinSPD;
    public int MaxSPD;

    public float RatioHab1;
    public float RatioHab2;
    public float RatioHab3;
    public float RatioHab4;
    public float RatioSPD;


    public string Descricao;

}
