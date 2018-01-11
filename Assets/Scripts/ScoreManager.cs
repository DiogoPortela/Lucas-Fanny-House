using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static bool won = false;
    public static Text drawText;

    private void Start()
    {
        drawText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    public static void Win()
    {
        drawText.text = "YOU WON";
        won = true;
    }

    public static void Loss()
    {
        drawText.text = "YOU LOSS";
        won = false;
    }
}
