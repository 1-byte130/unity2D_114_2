using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gamedirector : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI SurvivalTimeText; // 拖入顯示時間的文字
    public static float elapsedTime = 0f;          // 累計的時間
    private bool isRunning = true;
    void Start()
    {
        elapsedTime = 0f;
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        SurvivalTimeText.text = elapsedTime.ToString("F2");
    }
}
