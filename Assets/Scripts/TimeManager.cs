using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float startTime = 60f; // เวลาเริ่มต้น (วินาที)
    private float currentTime;
    public  Slider timeSlider;
    private bool isTimeOver = false;
    public GameOverManager gameOverManager;

    void Start()
    {
        currentTime = startTime;

        if (timeSlider != null)
        {
            timeSlider.maxValue = startTime;
            timeSlider.value = currentTime;
        }

        
    }

    void Update()
    {
        if (timeSlider == null || isTimeOver) return;

        // ลดเวลา
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0f, startTime);
        timeSlider.value = currentTime;

        // ถ้าเวลาหมด
        if (!isTimeOver && Mathf.Approximately(currentTime, 0f))
        {
            TriggerGameOver();
        }
    }

    // ฟังก์ชันเพิ่มเวลา (เช่น เก็บ Item)
    public void AddTime(float amount)
    {
        if (isTimeOver) return;

        currentTime += amount;
        currentTime = Mathf.Clamp(currentTime, 0f, startTime);

        if (timeSlider != null)
        {
            timeSlider.value = currentTime;
        }
    }

    // ฟังก์ชันลดเวลา (เช่น โดนกับดัก)
    public void ReduceTime(float amount)
    {
        if (isTimeOver) return;

        currentTime -= amount;
        currentTime = Mathf.Clamp(currentTime, 0f, startTime);

        if (timeSlider != null)
        {
            timeSlider.value = currentTime;
        }

        if (!isTimeOver && Mathf.Approximately(currentTime, 0f))
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        if (isTimeOver)
        {
            Debug.LogWarning("GameOver ถูกเรียกซ้ำ");
            return;
        }


        isTimeOver = true;
        Debug.Log("⏰ Time Over!");

        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOver();
        }


    }
}
