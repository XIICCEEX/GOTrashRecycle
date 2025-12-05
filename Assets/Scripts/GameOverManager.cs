using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;   // ลาก Panel จาก Canvas
    public AudioSource bgmSource;      // ลาก AudioSource ที่เล่นเพลงมาใส่

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // ซ่อน Panel ตอนเริ่มเกม
        }
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f; // หยุดเวลาในเกม

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // แสดง Panel GameOver
        }

        if (bgmSource != null && bgmSource.isPlaying)
        {
            bgmSource.Stop(); // หยุดเพลง
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // รีเซ็ตเวลา
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex); // โหลดซีนปัจจุบันใหม่

        if (bgmSource != null)
        {
            bgmSource.Play(); // เล่นเพลงใหม่
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}
