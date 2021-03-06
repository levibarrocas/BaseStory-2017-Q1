﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorPersonagem : MonoBehaviour
{
    [SerializeField]
    string[] NomesMasculino;
    [SerializeField]
    string[] NomesFeminino;
    [SerializeField]
    string[] Sobrenomes;
    [SerializeField]
    public List<Personagem> Personagems = new List<Personagem>();

    [SerializeField]
    ProfissaoPersonagem[] Profisoes;

    [SerializeField]
    public Sprite[] PersonagemMasculinos;

    [SerializeField]
    public Sprite[] PersonagemFemininos;

    public static GeradorPersonagem GP;

    private void Awake()
    {
        if (GP == null)
        {
            DontDestroyOnLoad(gameObject);
            GP = this;
        }
        else if (GP != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            Personagems.Add(CriarPersonagemAleatorio(i));
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            Personagems.Add(CriarPersonagemAleatorio());
            Personagems.Add(CriarPersonagemAleatorio(3));

        }
    }

    public Personagem CriarPersonagemAleatorio()
    {
        int R1 = Random.Range(0, 2);
        Personagem PER = new Personagem();
        if (R1 == 0)
        {
            PER.Sexo = true;
            int R2 = Random.Range(0, NomesMasculino.Length);
            int R3 = Random.Range(0, Sobrenomes.Length);
            int R5 = Random.Range(0, PersonagemMasculinos.Length);
            PER.NomeP = NomesMasculino[R2];
            PER.Sobrenome = Sobrenomes[R3];
            PER.ImageIndex = R5;
        }
        else
        {
            PER.Sexo = false;
            int R2 = Random.Range(0, NomesFeminino.Length);
            int R3 = Random.Range(0, Sobrenomes.Length);
            int R5 = Random.Range(0, PersonagemFemininos.Length);
            PER.NomeP = NomesFeminino[R2];
            PER.Sobrenome = Sobrenomes[R3];
            PER.ImageIndex = R5;
        }

        int R4 = Random.Range(0, Profisoes.Length);

        PER.Habilidade1 = Random.Range(Profisoes[R4].MinHab1, Profisoes[R4].MaxHab1);
        PER.Habilidade2 = Random.Range(Profisoes[R4].MinHab2, Profisoes[R4].MaxHab2);
        PER.Habilidade3 = Random.Range(Profisoes[R4].MinHab3, Profisoes[R4].MaxHab3);
        PER.Habilidade4 = Random.Range(Profisoes[R4].MinHab4, Profisoes[R4].MaxHab4);
        PER.Velocidade = Random.Range(Profisoes[R4].MinSPD, Profisoes[R4].MaxSPD);
        PER.Profisao = Profisoes[R4];

        PER.Salario = (int)PER.Habilidade1 + (int)PER.Habilidade2 + (int)PER.Habilidade3 + (int)PER.Habilidade4 + (int)PER.Velocidade;

        return PER;
    }

    public Personagem CriarPersonagemAleatorio(int Level)
    {
        Personagem PER = CriarPersonagemAleatorio();

        for (int i = 0; i < Level; i++)
        {
            PER.LevelUp(false);
        }

        return PER;
    }

}

