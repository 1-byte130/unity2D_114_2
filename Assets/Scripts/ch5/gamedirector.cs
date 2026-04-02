using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("UI 設定")]
    public TextMeshProUGUI SurvivalTimeText; // 拖入顯示時間的文字
    public Image hpGauge;                    // 拖入血量條 Image (Filled 模式)

    private float elapsedTime = 0f;          // 累計的時間
    private bool isRunning = true;
    void Start()
    {
        elapsedTime = 0f;
        isRunning = true;
    }
    void Update()
    {
        
        elapsedTime += Time.deltaTime;
        SurvivalTimeText.text = elapsedTime.ToString("F2");
        // 3. 更新介面
        if (elapsedTime >= 5)
        {
            Time.timeScale = 0f;
            if (hpGauge.fillAmount > 0.65f)
            {
                SurvivalTimeText.text = "success";
                if (Input.GetMouseButtonDown(0)) SceneManager.LoadScene("ch6");
            }
            else
            {
                SurvivalTimeText.text = "fail";
                if (Input.GetMouseButtonDown(0))
                {
                    hpGauge.fillAmount = 1;
                    Time.timeScale = 1f;
                    elapsedTime=0;
                }
            }   
        }
        if (Input.GetKey("escape")) {
            Time.timeScale = 1f;
            SceneManager.LoadScene("ch5+6"); 
        }
    }    
   
    public void DecreaseHp()
    {
        this.hpGauge.fillAmount -= 0.1f;       
    }
    // Update is called once per frame

}
