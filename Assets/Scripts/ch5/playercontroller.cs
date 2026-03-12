using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ch5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-2, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(2, 0, 0);
        }
        // 假設你的邊界範圍是 X: -10 到 10, Y: -5 到 5
        float clampedX = Mathf.Clamp(transform.position.x, -10f, 10f);

        // 將限制後的座標重新賦予給角色
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
