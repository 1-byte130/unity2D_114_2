using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class gamedirector : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject hpGauge;
    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");  
    }

    // Update is called once per frame
    public void DecreseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }
}
