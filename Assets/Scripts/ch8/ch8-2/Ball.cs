using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;

    public float baseSpeed = 5f;
    public float maxSpeed = 30f; // 建議給一個上限，例如 30
    public float speedMultiplier = 1.1f; // 建議 1.1 即可，100 會瞬間飛走
    public float currentSpeed { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        rb.position = Vector2.zero;
        // 重要：重置位置時，速度也要回歸初始值
        currentSpeed = baseSpeed;
    }

    public void AddStartingForce()
    {
        currentSpeed = baseSpeed; // 確保每回合開始是基礎速度

        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f) : Random.Range(0.5f, 1f);

        Vector2 direction = new Vector2(x, y).normalized;
        rb.velocity = direction * currentSpeed;
    }

    private void FixedUpdate()
    {
        // 只有當球在移動時才強修正速度
        if (rb.velocity != Vector2.zero)
        {
            // 保持方向不變，但強制套用 currentSpeed
            rb.velocity = rb.velocity.normalized * currentSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 1. 撞到球拍加速
        if (collision.gameObject.CompareTag("Paddle"))
        {
            currentSpeed = Mathf.Min(currentSpeed * speedMultiplier, maxSpeed);
            Debug.Log("球速提升至: " + currentSpeed);
        }

        // 2. 解決你說的「得分功能消失」
        // 如果你的牆壁是實體的（OnCollision），得分邏輯要寫在這裡
        if (collision.gameObject.CompareTag("Wall"))
        {
            // 這裡可以不寫，因為你 ScoringZone 已經有寫了
            // 但要確保 ScoringZone 的物體 Tag 是 Goal 且 IsTrigger 有勾或沒勾要一致
        }
    }
}