using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour {

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

	
	public string ClasseEspecial;
	
	// True para homem e false para mulher
	public bool Sexo;
	
	public int CorDoCabelo;
	public int CorDaPele;
	public int Camisa;
	public int Calca;
	
	string Nome(bool Sobrenome){
		if(Sobrenome){
			return NomeP + " " + Sobrenome;
		} else {
			return NomeP;
		}
	}
	
	
	
	
}
