using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTest : MonoBehaviour
{
    public TextMeshProUGUI stage1;
    public TextMeshProUGUI stage2;
    public TextMeshProUGUI stage3;
    public TextMeshProUGUI stage4;

    // Start is called before the first frame update
    void Start()
    {
        stage1.text = "Stage 1 : " + HighScore.Load(1).ToString();
        stage2.text = "Stage 2 : " + HighScore.Load(2).ToString();
        stage3.text = "Stage 3 : " + HighScore.Load(3).ToString();
        stage4.text = "Stage 4 : " + HighScore.Load(4).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
