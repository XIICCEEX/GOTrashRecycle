using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro; 

public class ScoreScript : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;
    [Header("Sound Effects")]
    public AudioSource audioSource;     // เอาไว้เล่นเสียง
    public AudioClip scoreClip;         // เสียงตอนเก็บแต้ม
    public AudioClip loseScoreClip;

    void Start()
    {
        UpdateScoreUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        switch (other.tag)
        {
            case "Red Can":
                AddScore(1);
                PlayScoreSound(true);
                Destroy(other.gameObject);
                break;

            case "Blue Can":
                AddScore(1);
                PlayScoreSound(true);
                Destroy(other.gameObject);
                break;

            case "Bottle":
                AddScore(2);
                PlayScoreSound(true);
                Destroy(other.gameObject);
                break;

            case "Coin":
                AddScore(5);
                PlayScoreSound(true);
                Destroy(other.gameObject);
                break;

            case "Fish":
                AddScore(-1);
                PlayScoreSound(false);
                Destroy(other.gameObject);
                break;
            case "Bomb":
                AddScore(-5);
                PlayScoreSound(false);
                Destroy(other.gameObject);
                break;

            case "Ground":
                Destroy(other.gameObject);
                break;
        }

      
        
    }

    void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }
    void PlayScoreSound(bool positive)
    {
        if (audioSource == null) return;

        if (positive && scoreClip != null)
        {
            audioSource.PlayOneShot(scoreClip);
        }
        else if (!positive && loseScoreClip != null)
        {
            audioSource.PlayOneShot(loseScoreClip);
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); // โชว์เฉพาะตัวเลข
        }
    }

}