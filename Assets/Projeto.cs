using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Projeto : System.Object {

    public string Nome;
    public int TipoProjeto;
    public float[] Qualidade1;
    public float[] Qualidade2;
    public float[] Qualidade3;

    public int CharactersWorking;

    public float MoneyGenerationRatio;

    public Personagem Lider;

    public Personagem[] Participantes;
    [SerializeField]
    int QualidadeFull1;
    [SerializeField]
    int QualidadeFull2;
    [SerializeField]
    int QualidadeFull3;

    public int InteractionsWIthProject;
    float QualidadeFull(int A)
    {
        float Total = 1;
        for (int i = 0; i > Participantes.Length; i++)
        {
            if (A == 0)
            {
                Total += Qualidade1[i];
            } else if (A == 1)
            {
                Total += Qualidade2[i];
            }
            else if (A == 2)
            {
                Total += Qualidade3[i];
            }
        }
        return Total;
    }


    public void AddProgress(int Quality1,int Quality2,int Quality3,int Slot)
    {
        Qualidade1[Slot] += Quality1;
        Qualidade2[Slot] += Quality2;
        Qualidade3[Slot] += Quality3;
        InteractionsWIthProject++;
        QualidadeFull1 = (int)QualidadeFull(0);
        QualidadeFull1 = (int)QualidadeFull(1);
        QualidadeFull1 = (int)QualidadeFull(2);
    }
    
    public void CompleteProject()
    {
        if(TipoProjeto == 0)
        {
            GenerateFirstRatio();
        } else if (TipoProjeto == 1)
        {

        }
        else if (TipoProjeto == 2)
        {

        } else
        {

        }

    }

    public void GenerateFirstRatio()
    {
        float R = Random.Range(0.5f, 1.5f);
        R *= Lider.Habilidade4;
        float Total = QualidadeFull(0) + QualidadeFull(1) + QualidadeFull(2);
        Total *= R;
        MoneyGenerationRatio = Total;
    }

    public void GainProjectMoney()
    {
        CurrencyManager.CM.Reais.Gain((int)MoneyGenerationRatio);
        MoneyGenerationRatio *= Random.Range(0.4f, 0.9f);
    }
}
