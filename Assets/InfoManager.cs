using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour {

     string OrganizationName;
     int OrganizationLevel;
     int DateOfCreation;
     int XP;
     int NextLevelXP = 3000;

    public static InfoManager IM;

    private void Awake()
    {
        if (IM == null)
        {
            IM = this;
        }
        else if (IM != this)
        {
            Destroy(gameObject);
        }
    }

    public int Level()
    {
        return OrganizationLevel;
    }

    public string Name()
    {
        return OrganizationName;
    }

    public int XPInfo()
    {
        return XP;
    }

    public int NextXPInfo()
    {
        return NextLevelXP;
    }

    public int Date()
    {
        return DateOfCreation;
    }

    public void GainEXP(int Ammount)
    {
        XP += Ammount;
        if(XP > NextLevelXP)
        {
            OrganizationLevel++;
            NextLevelXP *= 4;
        }
    }

    public void CreateOrganization(string Name)
    {
        OrganizationName = Name;
        DateOfCreation = TimeManager.TM.IntDate();
        OrganizationLevel = 1;
        NextLevelXP = 1000;
        XP = 0;
    }

    public void LoadOrganization(string Name,int Date,int Level,int NextXP,int XPA)
    {
        OrganizationName = Name;
        DateOfCreation = Date;
        OrganizationLevel = Level;
        NextLevelXP = NextXP;
        XP = XPA;
    }
}
[System.Serializable]
public class InfoSerial
{
    string OrganizationName;
    int OrganizationLevel;
    int DateOfCreation;
    int XP;
    int NextLevelXP;

    public void SerializeInfo()
    {
        OrganizationName = InfoManager.IM.Name();
        DateOfCreation = InfoManager.IM.Date();
        OrganizationLevel = InfoManager.IM.Level();
        XP = InfoManager.IM.XPInfo();
        NextLevelXP = InfoManager.IM.NextXPInfo();
    }

    public void LoadData()
    {
        InfoManager.IM.LoadOrganization(OrganizationName, OrganizationLevel, DateOfCreation, XP, NextLevelXP);
    }
}
