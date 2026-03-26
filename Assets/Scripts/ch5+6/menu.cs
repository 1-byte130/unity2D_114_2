using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ch5()
    {
        SceneManager.LoadScene("ch5");
    }
    public void ch6()
    {
        SceneManager.LoadScene("ch6");
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("ch5");
        }
        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("ch6");
        }
    }
}
