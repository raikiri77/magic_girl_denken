using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMultipleObjects : MonoBehaviour
{
    [Header("移動経路")] public GameObject[] movePoint;
    [Header("動かすオブジェクト")] public Rigidbody2D[] targetRbs;
    [Header("速さ")] public float speed = 1.0f;

    private int nowPoint = 0;
    private bool returnPoint = false;
    private Vector2[] initialOffsets;

    private void Start()
    {
        if (movePoint != null && movePoint.Length > 0 && targetRbs != null && targetRbs.Length > 0)
        {
            initialOffsets = new Vector2[targetRbs.Length];
            
            // targetRbs[0] を基準とした各オブジェクトの相対位置を保持
            Vector2 basePosition = targetRbs[0].position;

            for (int i = 0; i < targetRbs.Length; i++)
            {
                if (targetRbs[i] != null)
                {
                    initialOffsets[i] = targetRbs[i].position - basePosition;
                }
            }

            // 初期位置を movePoint[0] に設定したい場合は、全体の相対関係を保ったまま移動
            Vector2 startPointPos = movePoint[0].transform.position;
            for (int i = 0; i < targetRbs.Length; i++)
            {
                if (targetRbs[i] != null)
                {
                    targetRbs[i].position = startPointPos + initialOffsets[i];
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (movePoint == null || movePoint.Length < 2 || targetRbs == null || targetRbs.Length == 0 || targetRbs[0] == null)
            return;

        // 次の目標地点のインデックスを計算
        int nextPoint = returnPoint ? nowPoint - 1 : nowPoint + 1;
        Vector2 targetPos = movePoint[nextPoint].transform.position;

        // 目標地点までの距離と、このフレームでの移動量を比較
        float distance = Vector2.Distance(targetRbs[0].position, targetPos);
        float step = speed * Time.fixedDeltaTime; // FixedUpdate内では fixedDeltaTime を使用

        if (distance > step)
        {
            // 目標地点に向かって移動
            Vector2 toVector = Vector2.MoveTowards(targetRbs[0].position, targetPos, step);
            Vector2 delta = toVector - targetRbs[0].position;

            for (int i = 0; i < targetRbs.Length; i++)
            {
                if (targetRbs[i] != null)
                {
                    targetRbs[i].MovePosition(targetRbs[i].position + delta);
                }
            }
        }
        else
        {
            // 到着処理：ピッタリ目標位置に合わせる
            for (int i = 0; i < targetRbs.Length; i++)
            {
                if (targetRbs[i] != null)
                {
                    targetRbs[i].MovePosition(targetPos + initialOffsets[i]);
                }
            }

            // 進行方向の更新
            nowPoint = nextPoint;

            if (!returnPoint && nowPoint >= movePoint.Length - 1)
            {
                returnPoint = true;
            }
            else if (returnPoint && nowPoint <= 0)
            {
                returnPoint = false;
            }
        }
    }
}