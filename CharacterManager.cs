using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    GeradorPersonagem GP;

    [SerializeField]
    public List<Personagem> Funcionarios = new List<Personagem>();

    [SerializeField]
    public List<Personagem> FuncionariosDisponiveis = new List<Personagem>();
    [SerializeField]
    public List<Projeto> ProjetosCompletos = new List<Projeto>();
    public Projeto ProjetoAtivo;

    public float PlayerLevel;

    public float ProjectProgress;
    public float TimeToComplete;
    bool ProjectActive;

    // Use this for initialization
    void Start() {
        GP = GetComponent<GeradorPersonagem>();
    }

    public void AddRandomCharacter()
    {
        Funcionarios.Add(GP.CriarPersonagemAleatorio());
    }

    public void GerarFuncionariosDisponiveis(int N)
    {
        FuncionariosDisponiveis.Clear();
        for(int i = 0;i< N; i++)
        {
            float R = Random.Range(PlayerLevel / 2, PlayerLevel * 2);
            FuncionariosDisponiveis.Add(GP.CriarPersonagemAleatorio((int)R));
        }

    }

    public void StartProject()
    {
        if (!ProjectActive)
        {
            ProjectActive = true;
            ProjetoAtivo = new Projeto();
        }
    }

    public void StartProject(string Nome)
    {
        if (!ProjectActive)
        {
            ProjectActive = true;
            ProjetoAtivo = new Projeto();
            ProjetoAtivo.Nome = Nome;
        }
    }

    // Update is called once per frame
    void Update () {
        if (ProjectActive)
        {
            ProjectProgress += Time.deltaTime;
            for(int i = 0;i < Funcionarios.Count; i++)
            {
                ProjetoAtivo.Qualidade1 += Funcionarios[i].Habilidade1;
                ProjetoAtivo.Qualidade2 += Funcionarios[i].Habilidade2;
                ProjetoAtivo.Qualidade3 += Funcionarios[i].Habilidade3;
            }
            if(ProjectProgress >= TimeToComplete)
            {
                ProjetosCompletos.Add(ProjetoAtivo);
                ProjectActive = false;
                ProjectProgress = 0;
            }
        }
	}
}
