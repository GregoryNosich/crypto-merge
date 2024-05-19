using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverText : MonoBehaviour
{
    public TextMeshProUGUI myText;
    public TextMeshProUGUI restartText;

    void Update()
    {
        myText.enabled = CollisionController.gameOver;
        restartText.enabled = CollisionController.gameOver;
    }
}
