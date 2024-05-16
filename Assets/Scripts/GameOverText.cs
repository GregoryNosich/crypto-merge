using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverText : MonoBehaviour
{
    public TextMeshProUGUI myText;

    void Update()
    {
        myText.enabled = CollisionController.gameOver;
    }
}
