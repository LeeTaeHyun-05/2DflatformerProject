using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScore 
{
    private const string KEY = "HighScore";

    public static int Load(int stage)
    {
        //stage1로 불렀을 때, HighScore_1의 데이터를 불러온다
        return PlayerPrefs.GetInt(KEY + "_" + stage, 0);
    }

    public static void TrySet(int stage, int newScore)
    {
        if (newScore <= Load(stage))
            return;

        PlayerPrefs.SetInt(KEY + "_" + stage, newScore);
        PlayerPrefs.Save();
    }
}
