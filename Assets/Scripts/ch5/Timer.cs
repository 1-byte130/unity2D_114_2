using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("UI 設定")]
    public TextMeshProUGUI SurvivalTimeText; // 拖入顯示時間的文字
    public Image hpGauge;                    // 拖入血量條 Image (Filled 模式)

    private float elapsedTime = 0f;          // 累計的時間
    private bool isRunning = true;           // 是否正在計時

    void Start()
    {
        // 確保遊戲開始時時間歸零
        elapsedTime = 0f;
        isRunning = true;
    }

    void Update()
    {
        // 如果計時器已經停止，就什麼都不做（這能防止血量回滿後計時器自動重啟）
        if (!isRunning) return;

        // 1. 檢查血量
        if (hpGauge.fillAmount == 0)
        {
            Time.timeScale = 0f;            
        }
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            hpGauge.fillAmount = 1.0f;
            elapsedTime = 0;
        }
        // 2. 計時邏輯：使用 Time.deltaTime 進行累加比較穩定
        elapsedTime += Time.deltaTime;

        // 3. 更新介面
        if (SurvivalTimeText != null)
        {
            SurvivalTimeText.text = elapsedTime.ToString("f1") + "s";
        }
    }

    // 停止計時的功能
    public void StopTimer()
    {
        if (isRunning) // 確保只執行一次
        {
            isRunning = false;
            Debug.Log("【遊戲結束】貓咪血量歸零，時間停在：" + elapsedTime.ToString("f1") + "s");
            // 你可以在這裡呼叫顯示「遊戲結束視窗」的程式碼
        }
    }

    // 如果你有「重新開始」按鈕，點擊時呼叫這個方法
    public void ResetTimer()
    {
        elapsedTime = 0f;
        isRunning = true;
        Debug.Log("【重新計時】");
    }
}