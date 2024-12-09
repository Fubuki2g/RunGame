using UnityEngine;

public class TriggerAreaManager : Singleton<TriggerAreaManager>
{
    // �v���C���[�Ȃǂ̃^�O���w��
    [SerializeField] private string targetTag = "Player";

    // �g���K�[�ɓ������Ƃ��̏���
    private void OnTriggerEnter(Collider other)
    {
        // �^�O����v�����ꍇ�̂ݏ��������s
        if (other.CompareTag(targetTag))
        {
            // ���̃G���A���폜
            Destroy(gameObject);

            RandomFloorManager.Instance.GenerateRandomFloors();
        }
    }

}