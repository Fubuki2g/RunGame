using UnityEngine;

public class RandomFloorManager : Singleton<RandomFloorManager>
{
    [SerializeField] private GameObject[] floorPrefabs; // �����_���ɐ�������v���n�u
    [SerializeField] private Vector3 basePosition;      // �����̊�ƂȂ�ʒu�ix, y�͌Œ�j
    [SerializeField] private float startZ = 100f;         // �J�n��z���W
    [SerializeField] private float stepZ = 100f;          // z���W�̑�����
    [SerializeField] private float floorPosition;

    /// <summary>
    /// �����_���ȃv���n�u���w�肵�����W�ɐ������܂��B
    /// </summary>
    public void GenerateRandomFloors()
    {
        if (floorPrefabs.Length == 0)
        {
            Debug.LogWarning("FloorPrefabs���ݒ肳��Ă��܂���I");
            return;
        }

        // �V����z���W���v�Z
        floorPosition += stepZ;

        // �����_���ȃC���f�b�N�X���擾
        int randomIndex = Random.Range(0, floorPrefabs.Length);

        // �v���n�u�𐶐�
        Vector3 position = new Vector3(basePosition.x, basePosition.y, floorPosition);
        GameObject randomFloor = Instantiate(floorPrefabs[randomIndex], position, Quaternion.identity);
        randomFloor.name = "RandomFloor"; // ���O��ݒ�
    }
}
