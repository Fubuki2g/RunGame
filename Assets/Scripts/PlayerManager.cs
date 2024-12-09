using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public float moveSpeed = 5f; // �ʏ�ړ����x
    public float runSpeed = 10f; // ���鑬�x
    public float jumpForce = 5f; // �W�����v�̗�
    public ParticleSystem runEffect; // ���鎞�̃G�t�F�N�g
    private bool isGrounded; // �n�ʂɂ��邩�ǂ����̃t���O
    private bool clear;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // �G�t�F�N�g���~��Ԃɂ���
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
        float horizontal = Input.GetAxis("Horizontal"); // A/D�L�[�܂��͖��L�[���E
        float vertical = Input.GetAxis("Vertical"); // W/S�L�[�܂��͖��L�[�㉺

        // �V�t�g�L�[�������Ă���ԁA�ړ����x��ύX
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

        // �V�t�g�L�[��������Ă���ԃG�t�F�N�g��L���ɂ���
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
        // �n�ʂɐڐG�����Ƃ�
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // �n�ʂ��痣�ꂽ�Ƃ�
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

}
