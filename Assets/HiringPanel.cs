using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiringPanel : MonoBehaviour {
    [SerializeField]
    GameObject GO;   

    public void Activate()
    {
        GO.SetActive(true);
    }
}
