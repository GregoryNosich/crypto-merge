using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public static int Score = 0;

    void Update()
    {
        textField.text = Score.ToString() + " $";
    }
}
