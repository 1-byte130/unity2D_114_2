using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject hpGauge;
    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
    }
    public void DecreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
        if (hpGauge.GetComponent<Image>().fillAmount == 0)
        {
            hpGauge.GetComponent<Image>().fillAmount = 1;
        }
    }
    // Update is called once per frame

}
