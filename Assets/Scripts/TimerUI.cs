using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI Timertext;
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        Timertext.text = "무적시간 : " + Timer.ToString("20.00");
    }
}
