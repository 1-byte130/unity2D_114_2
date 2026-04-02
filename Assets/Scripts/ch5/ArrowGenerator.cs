using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowprfab;
    float span = 1.0f;
    float delta = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        this.span -= 0.5f * Time.deltaTime;
        this.span = Mathf.Max(0.2f, this.span);
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go=Instantiate(arrowprfab);
            int px = Random.Range(-6, 7);
            go.transform.position=new Vector3(px, 7, 0);
        }
    }
}
