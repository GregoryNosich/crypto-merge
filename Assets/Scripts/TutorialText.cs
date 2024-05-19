using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    public GameObject TextObjectDesktop;
    public GameObject TextObjectMobile;

    void Start()
    {
        if (Application.isMobilePlatform)
        {
            TextObjectDesktop.SetActive(false);
            TextObjectMobile.SetActive(true);
        }
        else
        {
            TextObjectDesktop.SetActive(true);
            TextObjectMobile.SetActive(false);
        }
    }
}
