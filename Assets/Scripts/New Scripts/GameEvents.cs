using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//สำหรับคะแนน
public static class GameEvents
{
    // คะแนนเปลี่ยน
    public static event Action<int> OnScoreChanged;

    // เวลาเปลี่ยน 
    public static event Action<float> OnTimeChanged;

    // เกมจบ
    public static event Action OnGameOver;

    public static void RaiseScoreChanged(int newScore)
    {
        OnScoreChanged?.Invoke(newScore);
    }

    public static void RaiseTimeChanged(float normalizedTime)
    {
        OnTimeChanged?.Invoke(normalizedTime);
    }

    public static void RaiseGameOver()
    {
        OnGameOver?.Invoke();
    }
}
