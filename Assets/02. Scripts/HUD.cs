using System;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private Text myText;

    private void Awake()
    {
        myText = GetComponent<Text>();
    }


    private void LateUpdate()
    {
        float score = GameManager.instance.score;

        myText.text = $"score: {score}";
    }
}
