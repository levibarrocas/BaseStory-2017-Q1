using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {


    [SerializeField]
    public List<Personagem> Funcionarios = new List<Personagem>();

    public static CharacterManager CM;

    private void Awake()
    {
        if (CM == null)
        {
            DontDestroyOnLoad(gameObject);
            CM = this;
        }
        else if (CM != this)
        {
            Destroy(gameObject);
        }
    }
    public void AddRandomCharacter()
    {
        Funcionarios.Add(GeradorPersonagem.GP.CriarPersonagemAleatorio());
    }

    public void StartProject()
    {

        ProjectManager.PM.StartProject();
    }

    public void StartProject(string Nome)
    {
        ProjectManager.PM.StartProject(Nome);
    }

    // Update is called once per frame
    void Update () {
        for (int i = 0; i < Funcionarios.Count; i++)
        {
            Funcionarios[i].PassTime();
        }
	}
}
