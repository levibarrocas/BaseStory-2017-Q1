using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireableManager : MonoBehaviour {


    [SerializeField]
    public List<Personagem> Contrataveis = new List<Personagem>();

    public int HiringPower;

    public int LastGeneration;

    public static HireableManager HM;

    private void Awake()
    {
        if (HM == null)
        {
            HM = this;
        }
        else if (HM != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (LastGeneration == 0)
        {
            GenerateContrataveis();
        }
    }

    private void Update()
    {
        if(LastGeneration+30 < TimeManager.TM.IntDate())
        {
            GenerateContrataveis();
        }
    }


    public void GenerateContrataveis()
    {
        Contrataveis.Clear();
        LastGeneration = TimeManager.TM.IntDate();
        for (int i = 0; i < HiringPower; i++)
        {
            int R = Random.Range(InfoManager.IM.Level() / 2, InfoManager.IM.Level() * 2);
            Contrataveis.Add(GeradorPersonagem.GP.CriarPersonagemAleatorio(R));
        }
    }

}
