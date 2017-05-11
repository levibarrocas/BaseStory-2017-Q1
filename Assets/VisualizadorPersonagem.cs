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


    public void MostrarPersonagem(Personagem PER)
    {
        Panel.SetActive(true);
        Nome.text = PER.Nome(true);
        Profissao.text = PER.Profisao.Classe;
        Habilidade1.text = PER.Habilidade1.ToString();
        Habilidade2.text = PER.Habilidade2.ToString();
        Habilidade3.text = PER.Habilidade3.ToString();
        Habilidade4.text = PER.Habilidade4.ToString();
        Level.text = "Level: " + PER.Level;
        Salario.text = Mathf.Round(PER.Salario).ToString();

    }


}
