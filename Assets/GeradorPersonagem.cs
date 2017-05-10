using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorPersonagem : MonoBehaviour {
    [SerializeField]
    string[] NomesMasculino;
    [SerializeField]
    string[] NomesFeminino;
    [SerializeField]
    string[] Sobrenomes;
	
	

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	Personagem CriarPersonagemAleatorio(){
		int R1 = Random.Range(0,1)
		Personagem PER;
		if(R1 == 0 {
			R1.Sexo = true;
			int R2 = Random.Range(0,NomesMasculino.Lenght);
			int R3 = Random.Range(0,Sobrenomes.Lenght);
			PER.NomeP = NomesMasculino[R2];
			PER.Sobrenome = Sobrenomes[R3];
		} else {
			R1.Sexo = false;
			int R2 = Random.Range(0,NomesFeminino.Lenght);
			int R3 = Random.Range(0,Sobrenomes.Lenght);
			PER.NomeP = NomesFeminino[R2];
			PER.Sobrenome = Sobrenomes[R3];
		}
		
		
		
	}
}
