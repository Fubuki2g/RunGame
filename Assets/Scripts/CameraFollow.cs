using UnityEngine;

public class CameraFollow : Singleton<CameraFollow>
{
    [SerializeField] private Transform target; // �J�������Ǐ]����^�[�Q�b�g
    [SerializeField] private Vector3 offset = new Vector3(0, 4, -8); // �^�[�Q�b�g����̃I�t�Z�b�g
    [SerializeField] private bool lockRotation = true; // �J�����̊p�x���Œ肷�邩
    [SerializeField] private float initialAngle = 20f; // �����p�x�i�c�����̉�]�p�x�j

    private void Start()
    {
        // �����p�x��ݒ�
        if (lockRotation)
        {
            transform.rotation = Quaternion.Euler(initialAngle, 0, 0);
        }
    }

    private void LateUpdate()
    {
        if (target == null) return;

        // �J�������^�[�Q�b�g�̈ʒu�ɍ��킹��
        transform.position = target.position + offset;

        // �J�����̊p�x���Œ肷��ꍇ
        if (lockRotation)
        {
            transform.rotation = Quaternion.Euler(initialAngle, 0, 0);
        }
    }
}
