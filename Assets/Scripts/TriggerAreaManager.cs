using UnityEngine;

public class TriggerAreaManager : Singleton<TriggerAreaManager>
{
    // プレイヤーなどのタグを指定
    [SerializeField] private string targetTag = "Player";

    // トリガーに入ったときの処理
    private void OnTriggerEnter(Collider other)
    {
        // タグが一致した場合のみ処理を実行
        if (other.CompareTag(targetTag))
        {
            // このエリアを削除
            Destroy(gameObject);

            RandomFloorManager.Instance.GenerateRandomFloors();
        }
    }

}