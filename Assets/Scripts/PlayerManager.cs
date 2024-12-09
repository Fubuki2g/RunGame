using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public float moveSpeed = 5f; // 通常移動速度
    public float runSpeed = 10f; // 走る速度
    public float jumpForce = 5f; // ジャンプの力
    public ParticleSystem runEffect; // 走る時のエフェクト
    private bool isGrounded; // 地面にいるかどうかのフラグ
    private bool clear;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // エフェクトを停止状態にする
        if (runEffect != null)
        {
            runEffect.Stop();
        }
    }

    void Update()
    {
        Move();
        Jump();
        HandleRunEffect();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/Dキーまたは矢印キー左右
        float vertical = Input.GetAxis("Vertical"); // W/Sキーまたは矢印キー上下

        // シフトキーを押している間、移動速度を変更
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;

        Vector3 movement = new Vector3(horizontal, 0, vertical) * currentSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void HandleRunEffect()
    {
        if (runEffect == null) return;

        // シフトキーが押されている間エフェクトを有効にする
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!runEffect.isPlaying)
            {
                runEffect.Play();
            }
        }
        else
        {
            if (runEffect.isPlaying)
            {
                runEffect.Stop();
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // 地面に接触したとき
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // 地面から離れたとき
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

}
