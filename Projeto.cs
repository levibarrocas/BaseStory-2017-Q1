using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Projeto : System.Object {

    public string Nome;
    public int TipoProjeto;

    public float Qualidade1;
    public float Qualidade2;
    public float Qualidade3;

    public float BaseGeneration;
    public float Renda;
    public float GeracaoDeDinheiro;


    public Personagem[] Integrantes;

    void GerarRendaInicial()
    {
        if(TipoProjeto == 0)
        {
            BaseGeneration = (Qualidade1 * 2) + (Qualidade2 * 2) + (Qualidade3 * 0.8f);
            BaseGeneration = Mathf.Round(BaseGeneration);
            BaseGeneration *= 0.1f;
            GeracaoDeDinheiro = BaseGeneration;
        }

    }

    float GerarRenda()
    {
        float R = Random.Range(0.6f, 1.4f);
        return BaseGeneration * R;

    }

}
