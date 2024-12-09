using System.Collections.Generic;
using UnityEngine;

public class ModeChangeManager : MonoBehaviour
{
    // �Q�[�����[�h�̗񋓌^
    public enum GameMode
    {
        Mode1,
        Mode2,
        Mode3,
        Mode4
    }

    [Header("�ݒ肷��Q�[�����[�h")]
    public GameMode targetMode;

    // ���݂̃��[�h��ێ�
    private static GameMode currentMode;

    // ���[�h���Ƃ̏������i�[
    private static Dictionary<GameMode, System.Action> modeActions = new Dictionary<GameMode, System.Action>();

    private void Start()
    {
        // �K�v�ɉ����ď�����������ǉ�
        if (modeActions.Count == 0)
        {
            InitializeModes();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �v���C���[�ȂǓ���̃I�u�W�F�N�g���G�ꂽ�Ƃ��̂݃��[�h�ύX
        if (other.CompareTag("Player"))
        {
            ChangeMode(targetMode);
        }
    }

    public static void ChangeMode(GameMode newMode)
    {
        if (currentMode == newMode)
        {
            Debug.Log($"����{newMode}�ɂȂ��Ă��܂�");
            return;
        }

        currentMode = newMode;

        if (modeActions.TryGetValue(newMode, out var action))
        {
            Debug.Log($"�Q�[�����[�h��{newMode}�ɕύX");
            action?.Invoke();
        }
        else
        {
            Debug.LogWarning($"{newMode}�ɑΉ�����A�N�V�������o�^����Ă��܂���");
        }
    }

    private void InitializeModes()
    {
        // ���[�h���Ƃ̏�����o�^
        modeActions[GameMode.Mode1] = () => Debug.Log("Mode1: �������[�h�̏���");
        modeActions[GameMode.Mode2] = () => Debug.Log("Mode2: �G�������Ȃ�");
        modeActions[GameMode.Mode3] = () => Debug.Log("Mode3: �X�R�A��2�{�ɂȂ�");
        modeActions[GameMode.Mode4] = () => Debug.Log("Mode4: �������Ԃ��Z���Ȃ�");

        // �K�v�ɉ����Ă����ɐV�������[�h�̏�����ǉ�
    }
}
