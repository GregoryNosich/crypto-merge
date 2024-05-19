using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public bool isTurnedOn;
    public Sprite TurnedOn;
    public Sprite TurnedOff;

    void Start()
    {
        isTurnedOn = true;
        GetComponent<Image>().sprite = TurnedOn;
    }

    public void volumeOnOff()
    {
        if (isTurnedOn)
        {
            AudioListener.volume = 0f;
            isTurnedOn = false;
            GetComponent<Image>().sprite = TurnedOff;
        } 
        else
        {
            AudioListener.volume = 1f;
            isTurnedOn = true;
            GetComponent<Image>().sprite = TurnedOn;
        }
    }
}
