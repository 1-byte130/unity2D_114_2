using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayController : MonoBehaviour
{
    Rigidbody2D cat;
    Animator animatior;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalked = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        cat= GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
        this.animatior= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cat.AddForce(transform.up * jumpForce);
        }
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        float speedx = Mathf.Abs(cat.velocity.x);
        if(speedx < maxWalked)
        {
            cat.AddForce(transform.right * key * walkForce);
        }
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1,1);
        }
        cat.AddForce(transform.right * key * 30.0f);
        this.animatior.speed = speedx / 2.0f;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("²×ÂI");
    }
}
