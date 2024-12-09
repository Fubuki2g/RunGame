using UnityEngine;

public class CameraFollow : Singleton<CameraFollow>
{
    [SerializeField] private Transform target; // カメラが追従するターゲット
    [SerializeField] private Vector3 offset = new Vector3(0, 4, -8); // ターゲットからのオフセット
    [SerializeField] private bool lockRotation = true; // カメラの角度を固定するか
    [SerializeField] private float initialAngle = 20f; // 初期角度（縦方向の回転角度）

    private void Start()
    {
        // 初期角度を設定
        if (lockRotation)
        {
            transform.rotation = Quaternion.Euler(initialAngle, 0, 0);
        }
    }

    private void LateUpdate()
    {
        if (target == null) return;

        // カメラをターゲットの位置に合わせる
        transform.position = target.position + offset;

        // カメラの角度を固定する場合
        if (lockRotation)
        {
            transform.rotation = Quaternion.Euler(initialAngle, 0, 0);
        }
    }
}
