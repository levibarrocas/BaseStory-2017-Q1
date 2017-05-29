using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectManager : MonoBehaviour {

    [SerializeField]
    public List<Projeto> ProjetosCompletos = new List<Projeto>();
    public Projeto ProjetoAtivo;

    public float ProjectProgress;
    public float TimeToComplete;
    public bool ProjectActive;

    public static ProjectManager PM;

    private void Awake()
    {
        if (PM == null)
        {
            PM = this;
        }
        else if (PM != this)
        {
            Destroy(gameObject);
        }
    }
    public void StartProject()
    {
        if (!ProjectActive)
        {
            ProjetoAtivo = new Projeto();
            ProjetoAtivo.Qualidade1 = new float[CharacterManager.CM.Funcionarios.Count];
            ProjetoAtivo.Qualidade2 = new float[CharacterManager.CM.Funcionarios.Count];
            ProjetoAtivo.Qualidade3 = new float[CharacterManager.CM.Funcionarios.Count];
            ProjetoAtivo.CharactersWorking = CharacterManager.CM.Funcionarios.Count;
            ProjectActive = true;
        }
    }

    public void StartProject(string Nome)
    {
        if (!ProjectActive)
        {
            ProjetoAtivo = new Projeto();
            ProjetoAtivo.Nome = Nome;
            ProjetoAtivo.Qualidade1 = new float[CharacterManager.CM.Funcionarios.Count];
            ProjetoAtivo.Qualidade2 = new float[CharacterManager.CM.Funcionarios.Count];
            ProjetoAtivo.Qualidade3 = new float[CharacterManager.CM.Funcionarios.Count];
            ProjetoAtivo.CharactersWorking = CharacterManager.CM.Funcionarios.Count;
            ProjectActive = true;
        }
    }

    public void StartProject(string Nome,Personagem Lider)
    {
        if (!ProjectActive)
        {
            ProjetoAtivo = new Projeto();
            ProjetoAtivo.Nome = Nome;
            ProjetoAtivo.Lider = Lider;
            ProjetoAtivo.Qualidade1 = new float[CharacterManager.CM.Funcionarios.Count];
            ProjetoAtivo.Qualidade2 = new float[CharacterManager.CM.Funcionarios.Count];
            ProjetoAtivo.Qualidade3 = new float[CharacterManager.CM.Funcionarios.Count];
            ProjetoAtivo.CharactersWorking = CharacterManager.CM.Funcionarios.Count;
            ProjectActive = true;
        } else
        {
            Notification NOT = new Notification("Erro!", "Você já está fazendo um projeto!");
            NotificationSystem.NS.ShowNotification(NOT);
        }
    }

    public void StartProject(string Nome, int LiderSlot)
    {
        if (CharacterManager.CM.Funcionarios.Count < 1)
        {
            if (LiderSlot == 200)
            {
                if (!ProjectActive)
                {
                    ProjetoAtivo = new Projeto();
                    ProjetoAtivo.Nome = Nome;
                    ProjetoAtivo.Lider = CharacterManager.CM.Funcionarios[LiderSlot];
                    ProjetoAtivo.Participantes = CharacterManager.CM.Funcionarios.ToArray();
                    ProjetoAtivo.Qualidade1 = new float[CharacterManager.CM.Funcionarios.Count];
                    ProjetoAtivo.Qualidade2 = new float[CharacterManager.CM.Funcionarios.Count];
                    ProjetoAtivo.Qualidade3 = new float[CharacterManager.CM.Funcionarios.Count];
                    ProjetoAtivo.CharactersWorking = CharacterManager.CM.Funcionarios.Count;
                    ProjectActive = true;
                }
                else
                {
                    Notification NOT = new Notification("Erro!", "Você já está fazendo um projeto!");
                    NotificationSystem.NS.ShowNotification(NOT);
                }
            }
            else 
            {
                Notification NOT = new Notification("Erro!", "Você não escolheu um lider!");
                NotificationSystem.NS.ShowNotification(NOT);
            }
        } else {
            Notification NOT = new Notification("Erro!", "Voce precissa contratar funcionarios para poder fazer um projeto!");
            NotificationSystem.NS.ShowNotification(NOT);
        }
    }
    public void StartProject(string Nome, int LiderSlot,int ProjectType)
    {
        if (CharacterManager.CM.Funcionarios.Count > 0)
        {
            if (LiderSlot == 200)
            {
                if (!ProjectActive)
                {
                    ProjetoAtivo = new Projeto();
                    ProjetoAtivo.Nome = Nome;
                    ProjetoAtivo.TipoProjeto = ProjectType;
                    ProjetoAtivo.Lider = CharacterManager.CM.Funcionarios[LiderSlot];
                    ProjetoAtivo.Participantes = CharacterManager.CM.Funcionarios.ToArray();
                    ProjetoAtivo.Qualidade1 = new float[CharacterManager.CM.Funcionarios.Count];
                    ProjetoAtivo.Qualidade2 = new float[CharacterManager.CM.Funcionarios.Count];
                    ProjetoAtivo.Qualidade3 = new float[CharacterManager.CM.Funcionarios.Count];
                    ProjetoAtivo.CharactersWorking = CharacterManager.CM.Funcionarios.Count;
                    ProjectActive = true;
        }
        else
        {
            Notification NOT = new Notification("Erro!", "Você já está fazendo um projeto!");
            NotificationSystem.NS.ShowNotification(NOT);
        }
    }
            else 
            {
                Notification NOT = new Notification("Erro!", "Você não escolheu um lider!");
    NotificationSystem.NS.ShowNotification(NOT);
            }
        } else {
            Notification NOT = new Notification("Erro!", "Você precissa contratar funcionarios para poder fazer um projeto!");
NotificationSystem.NS.ShowNotification(NOT);
        }
    }

    public void AddProgress(int Qualidade1, int Qualidade2,int Qualidade3,int slot)
    {
        ProjetoAtivo.AddProgress(Qualidade1, Qualidade2, Qualidade3, slot);
    }

    void ProgressProject()
    {
        if (ProjectActive)
        {
            ProjectProgress += Time.deltaTime;
            for (int i = 0; i < CharacterManager.CM.Funcionarios.Count; i++)
            {
                CharacterManager.CM.Funcionarios[i].Work(i);
            }
            if (ProjectProgress >= TimeToComplete)
            {
                ProjetoAtivo.GenerateFirstRatio();
                ProjetosCompletos.Add(ProjetoAtivo);
                for (int i = 0; i < CharacterManager.CM.Funcionarios.Count; i++)
                {
                    int Total = 0;
                    Total += (int)ProjetoAtivo.Qualidade1[i];
                    Total += (int)ProjetoAtivo.Qualidade2[i];
                    Total += (int)ProjetoAtivo.Qualidade3[i];
                    CharacterManager.CM.Funcionarios[i].XP += (int)(Total * Random.Range(0.5f, 2f));
                }
                ProjectActive = false;
                ProjectProgress = 0;
            }
        }
    }

    void Update()
    {
        ProgressProject();
    }
}
