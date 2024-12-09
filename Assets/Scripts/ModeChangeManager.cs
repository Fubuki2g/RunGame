using System.Collections.Generic;
using UnityEngine;

public class ModeChangeManager : MonoBehaviour
{
    // ゲームモードの列挙型
    public enum GameMode
    {
        Mode1,
        Mode2,
        Mode3,
        Mode4
    }

    [Header("設定するゲームモード")]
    public GameMode targetMode;

    // 現在のモードを保持
    private static GameMode currentMode;

    // モードごとの処理を格納
    private static Dictionary<GameMode, System.Action> modeActions = new Dictionary<GameMode, System.Action>();

    private void Start()
    {
        // 必要に応じて初期化処理を追加
        if (modeActions.Count == 0)
        {
            InitializeModes();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーなど特定のオブジェクトが触れたときのみモード変更
        if (other.CompareTag("Player"))
        {
            ChangeMode(targetMode);
        }
    }

    public static void ChangeMode(GameMode newMode)
    {
        if (currentMode == newMode)
        {
            Debug.Log($"既に{newMode}になっています");
            return;
        }

        currentMode = newMode;

        if (modeActions.TryGetValue(newMode, out var action))
        {
            Debug.Log($"ゲームモードを{newMode}に変更");
            action?.Invoke();
        }
        else
        {
            Debug.LogWarning($"{newMode}に対応するアクションが登録されていません");
        }
    }

    private void InitializeModes()
    {
        // モードごとの処理を登録
        modeActions[GameMode.Mode1] = () => Debug.Log("Mode1: 初期モードの処理");
        modeActions[GameMode.Mode2] = () => Debug.Log("Mode2: 敵が強くなる");
        modeActions[GameMode.Mode3] = () => Debug.Log("Mode3: スコアが2倍になる");
        modeActions[GameMode.Mode4] = () => Debug.Log("Mode4: 制限時間が短くなる");

        // 必要に応じてここに新しいモードの処理を追加
    }
}
