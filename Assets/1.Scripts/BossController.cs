using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
   
    public float Timer = 5f;
    public GameObject coinPrefabs;
    
   

    public void Attack()
    {
       for (int i = 0; i <5; i++)
        {
          
            float y = Random.Range (-12f, 2f );
            Vector3 spawnTr = new Vector3(21f, y, 0f);
            Instantiate(coinPrefabs, spawnTr, Quaternion.identity);
        }
       
        
    }

      
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            Timer = 5f;
            Attack();
        }
       
    }

    

}
