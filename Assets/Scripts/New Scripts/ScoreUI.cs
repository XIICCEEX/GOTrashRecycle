using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//เพื่ออัปเดต UI
public class ScoreUI : MonoBehaviour
{
    public TMP_Text scoreText;

    private void OnEnable()
    {
        GameEvents.OnScoreChanged += HandleScoreChanged;
    }

    private void OnDisable()
    {
        GameEvents.OnScoreChanged -= HandleScoreChanged;
    }

    private void Start()
    {
        HandleScoreChanged(0);
    }

    private void HandleScoreChanged(int newScore)
    {
        if (scoreText != null)
            scoreText.text = newScore.ToString();
    }
}
