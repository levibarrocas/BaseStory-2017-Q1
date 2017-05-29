using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    float Tempo;
    // DayScale right now is 0.5f which means an hour is half a second;
    public float DayScale;

    public int Hours = 1;
    public int Days = 1;
    public int Weeks;
    public int Months;
    public int Years;

    public static TimeManager TM;

    private void Awake()
    {
        if(TM == null)
        {
            TM = this;
        } else if (TM != this)
        {
            Destroy(gameObject);
        }
    }

    public int IntDate()
    {
        int Total = 0;
        Total += Days;
        Total += (Months * 30);
        Total += (Years * 360);
        return Total;
    }

    public string ClockDate()
    {
        return Hours.ToString() + ":00 " + Days.ToString() + "/"  + (Months + 1).ToString() + "/200" + Years.ToString();
    }

    private void Update()
    {
        Tempo += Time.deltaTime;
        if (Tempo > DayScale)
        {
            Hours++;
            Tempo = 0;
            if (Hours > 23)
            {
                Hours = 0;
                Days++;
                if (Days > 6)
                {
                    Weeks++;
                    for (int i = 0; i < CharacterManager.CM.Funcionarios.Count; i++)
                    {
                        CharacterManager.CM.Funcionarios[i].PassTime();
                    }
                    if (Days  > 29)
                    {
                        Days = 0;
                        Weeks = 0;
                        Months++;
                        if (Months > 11)
                        {
                            Months = 0;
                            Years++;
                        }
                    }

                }
            }
        }

    }


}
