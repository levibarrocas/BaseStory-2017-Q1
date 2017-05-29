using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

public class SaveManager : MonoBehaviour {

    public static SaveManager SM;

    private void Awake()
    {
        if (SM == null)
        {
            DontDestroyOnLoad(gameObject);
            SM = this;
        }
        else if (SM != this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveCharacters()
    {
        if (File.Exists(Application.persistentDataPath + "/characters.dat"))
        {
            File.Delete(Application.persistentDataPath + "/characters.dat");
        }
        SerializableCharacters Characters = new SerializableCharacters();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/characters.dat", FileMode.Create);
        for (int i = 0; i < CharacterManager.CM.Funcionarios.Count; i++)
        {
            SerializableCharacter Test = new SerializableCharacter();
            Test.SerializeCharacter(CharacterManager.CM.Funcionarios[i]);
            Characters.Characters.Add(Test);
        }
        bf.Serialize(file, Characters);
        file.Close();
    }
    public void LoadCharacters()
    {
        CharacterManager.CM.Funcionarios.Clear();
        if (File.Exists(Application.persistentDataPath + "/characters.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/characters.dat", FileMode.Open);
            SerializableCharacters CHAS = (SerializableCharacters)bf.Deserialize(file);
            for (int i = 0; i < CHAS.Characters.Count; i++)
            {
                CharacterManager.CM.Funcionarios.Add(CHAS.Characters[i].UnSerializeCharacter());
            }
        }
    }
    }
[System.Serializable]
public class SerializableCharacters
{
    public List<SerializableCharacter> Characters = new List<SerializableCharacter>();
}

[System.Serializable]
public class SerializableCharacter
{

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

    public ProfissaoPersonagem Profisao;

    public void SerializeCharacter(Personagem PER)
    {
        NomeP = PER.NomeP;
        Sobrenome = PER.Sobrenome;
        Habilidade1 = PER.Habilidade1;
        Habilidade2 = PER.Habilidade2;
        Habilidade3 = PER.Habilidade3;
        Habilidade4 = PER.Habilidade4;
        Salario = PER.Salario;
        Level = PER.Level;
        Satisfacao = PER.Satisfacao;
        Profisao = PER.Profisao;
    }

    public Personagem UnSerializeCharacter()
    {
        Personagem CHA = new Personagem();
        CHA.NomeP = NomeP;
        CHA.Sobrenome = Sobrenome;
        CHA.Habilidade1 = Habilidade1;
        CHA.Habilidade2 = Habilidade2;
        CHA.Habilidade3 = Habilidade3;
        CHA.Habilidade4 = Habilidade4;
        CHA.Salario = Salario;
        CHA.Level = Level;
        CHA.Satisfacao = Satisfacao;
        CHA.Profisao = Profisao;

        return CHA;
    }
}
