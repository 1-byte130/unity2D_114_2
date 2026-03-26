using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayController : MonoBehaviour
{
    Rigidbody2D cat;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 15.0f;
    float maxWalked = 2.0f;
    float threshold = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        cat= GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
        this.animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&cat.velocity.y==0)
        {
            this.animator.SetTrigger("JumpTrigger");
            cat.AddForce(transform.up * jumpForce);
        }
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        if (Input.acceleration.x>this.threshold) key = 1;
        if (Input.acceleration.x <-this.threshold) key = -1;
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
        this.animator.speed = speedx / 2.0f;
        if (cat.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
        }
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("ch6");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("²×ÂI");
        SceneManager.LoadScene("ch5+6");
    }
}
