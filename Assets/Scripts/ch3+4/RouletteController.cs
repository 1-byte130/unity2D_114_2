using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 加上這行才能控制 UI 文字

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0;
    public Text resultText; // 在 Inspector 把畫面的 Text 拖進來
    bool isStopped = true;  // 用來判斷是否已經停止
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.rotSpeed = 10;
            this.isStopped = false;
            if (resultText != null) resultText.text = "抽獎中...";
        }
        transform.Rotate(0, 0, this.rotSpeed);
        rotSpeed *= 0.98f;
        // 當速度變得很慢且還沒顯示結果時，判定停止
        if (this.rotSpeed < 0.01f && this.rotSpeed > 0 && !isStopped)
        {
            this.rotSpeed = 0;
            this.isStopped = true;
            ShowResult(); // 呼叫顯示結果的 function
        }
        //if (transform.rotation.z <= 30 && transform.rotation.z >= -30)
        {
            //Debug.Log("兇");
        }
        //Debug.Log(transform.eulerAngles.z);
    }
    void ShowResult()
    {
        // 取得目前的角度
        float angle = transform.eulerAngles.z;
        string result = "";

        // 3. 根據角度判斷區塊 (6個區塊，每塊60度)
        // 注意：Unity 角度 0 是右邊，逆時針增加
        if (angle >= 30 && angle < 90) result = "大吉";
        else if (angle >= 150 && angle < 210) result = "小吉";
        else if (angle >= 210 && angle < 270) result = "末吉";
        else if (angle >= 270 && angle < 330) result = "中吉";
        else if (angle >= 330 && angle < 30) result = "凶";
        else result = "大凶";

        Debug.Log("結果是：" + result);

        // 顯示在 UI 上
        if (resultText != null)
        {
            resultText.text = "結果：" + result;
        }
    }
}
