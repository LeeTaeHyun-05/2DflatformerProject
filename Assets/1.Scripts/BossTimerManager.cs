using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossTimerManager : MonoBehaviour
{
    public float Timer = 30f;
    public TextMeshProUGUI alive;
    public TextMeshProUGUI Clear;
    public TextMeshProUGUI start;
    public GameObject Boss;
    
    


    // Start is called before the first frame update
    void Start()
    {
        Invoke("Caution", 5f);

    }
    
    void Caution ()
    {
        start.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 25)
        {
            alive.gameObject.SetActive(true);
        }
        alive.text = $"생존 시간:{Timer}";
        if(Timer < 0)
        {
            Destroy(Boss);
            alive.gameObject.SetActive(false);
            Clear.gameObject.SetActive(true);
            Invoke("SceneInvoke", 5f);
               
        }
    }
    void SceneInvoke()
    {
        SceneManager.LoadScene("End");
    }
}
