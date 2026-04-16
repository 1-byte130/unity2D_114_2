using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BallPrfab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isNewRoundCalled)
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject ball = Instantiate(BallPrfab);
                Rigidbody2D rc = ball.GetComponent<Rigidbody2D>();
                int px = Random.Range(-8, 8);
                int py = Random.Range(-1, 1);
                ball.transform.position = new Vector3(px, py, 0);
                float x = Random.value < 0.5f ? -1f : 1f;
                float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f)
                                              : Random.Range(0.5f, 1f);
                Vector2 direction = new Vector2(x, y).normalized;
                rc.AddForce(direction * 5f, ForceMode2D.Impulse);
            }
            GameManager.isNewRoundCalled = false;
        }
    }
}
