using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NotificationSystem : MonoBehaviour {

    [SerializeField]
    public List<Notification> Notifications = new List<Notification>();
    [SerializeField]
    Text Title;
    [SerializeField]
    Text PanelText;
    [SerializeField]
    GameObject NotificationPanel;
    [SerializeField]
    GameObject[] OtherPanels;


    public static NotificationSystem NS;

    private void Awake()
    {
        if (NS == null)
        {
            NS = this;
        }
        else if (NS != this)
        {
            Destroy(gameObject);
        }
    }

    public void ShowNotification(Notification NOTI)
    {
        Notifications.Add(NOTI);
        for(int i = 0;i < OtherPanels.Length; i++)
        {
            OtherPanels[i].SetActive(false);
        }
        NotificationPanel.SetActive(true);
        Title.text = NOTI.Title;
        PanelText.text = NOTI.NotificationText;

    }


}

public class Notification
{
    public string Title;
    public string NotificationText;

    public bool Read;

    public Notification(string TI,string TE)
    {
        Title = TI;
        NotificationText = TE;
    }
}
