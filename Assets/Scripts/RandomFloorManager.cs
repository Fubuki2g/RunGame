using UnityEngine;

public class RandomFloorManager : Singleton<RandomFloorManager>
{
    [SerializeField] private GameObject[] floorPrefabs; // ランダムに生成するプレハブ
    [SerializeField] private Vector3 basePosition;      // 生成の基準となる位置（x, yは固定）
    [SerializeField] private float startZ = 100f;         // 開始のz座標
    [SerializeField] private float stepZ = 100f;          // z座標の増加量
    [SerializeField] private float floorPosition;

    /// <summary>
    /// ランダムなプレハブを指定した座標に生成します。
    /// </summary>
    public void GenerateRandomFloors()
    {
        if (floorPrefabs.Length == 0)
        {
            Debug.LogWarning("FloorPrefabsが設定されていません！");
            return;
        }

        // 新しいz座標を計算
        floorPosition += stepZ;

        // ランダムなインデックスを取得
        int randomIndex = Random.Range(0, floorPrefabs.Length);

        // プレハブを生成
        Vector3 position = new Vector3(basePosition.x, basePosition.y, floorPosition);
        GameObject randomFloor = Instantiate(floorPrefabs[randomIndex], position, Quaternion.identity);
        randomFloor.name = "RandomFloor"; // 名前を設定
    }
}
