using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowLine : MonoBehaviour
{
    //[SerializeField]
    private bool drawArc = false;//放物線の描画

    //[SerializeField]
    private int segmentCount = 60;//構成する線

    
    [SerializeField,Tooltip("放物線の長さ")] private float predictionTime = 6.0F;

    
    [SerializeField, Tooltip("放物線のマテリアル")]
    private Material arcMaterial;

    
    [SerializeField, Tooltip("放物線の幅")]
    private float arcWidth = 0.02F;

    
    private LineRenderer[] lineRenderers;

    private ShotBullet shootBullet;//弾を打つスクリプト
    
    private Vector3 initialVelocity;//初速度

    private Vector3 arcStartPosition;//開始地点

    [SerializeField, Tooltip("着弾地点に表示するマーカーのPrefab")]
    private GameObject pointerPrefab;

    private GameObject pointerObject;

    private Animator ani;

    private PlayerStatus status;


    void Start()
    {
        // 放物線のLineRendererオブジェクトを用意
        CreateLineRendererObjects();

        // マーカーのオブジェクトを用意
        pointerObject = Instantiate(pointerPrefab, Vector3.zero, Quaternion.identity);
        pointerObject.SetActive(false);

        // 弾の初速度や生成座標を持つコンポーネント
        shootBullet = gameObject.GetComponent<ShotBullet>();

        ani = gameObject.GetComponent<Animator>();
        status = gameObject.GetComponent<PlayerStatus>();
    }

    void Update()
    {
        if (!status.isdead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                drawArc = true;
                ani.SetBool("ThrowPre", true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                drawArc = false;
                ani.SetTrigger("Throw");
                ani.SetBool("ThrowPre", false);
            }

            // 初速度と放物線の開始座標を更新
            initialVelocity = shootBullet.ShootVelocity;
            arcStartPosition = shootBullet.InstantiatePosition;

            if (drawArc)
            {
                // 放物線を表示
                float timeStep = predictionTime / segmentCount;
                bool draw = false;
                float hitTime = float.MaxValue;
                for (int i = 0; i < segmentCount; i++)
                {
                    // 線の座標を更新
                    float startTime = timeStep * i;
                    float endTime = startTime + timeStep;
                    SetLineRendererPosition(i, startTime, endTime, !draw);

                    // 衝突判定
                    if (!draw)
                    {
                        hitTime = GetArcHitTime(startTime, endTime);
                        if (hitTime != float.MaxValue)
                        {
                            draw = true; // 衝突したらその先の放物線は表示しない
                        }
                    }
                }

                // マーカーの表示
                if (hitTime != float.MaxValue)
                {
                    Vector3 hitPosition = GetArcPositionAtTime(hitTime);
                    ShowPointer(hitPosition);
                }
            }
            else
            {
                // 放物線とマーカーを表示しない
                for (int i = 0; i < lineRenderers.Length; i++)
                {
                    lineRenderers[i].enabled = false;
                }
                pointerObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// 指定時間に対するアーチの放物線上の座標を返す
    /// </summary>
    /// <param name="time">経過時間</param>
    /// <returns>座標</returns>
    private Vector3 GetArcPositionAtTime(float time)
    {
        return (arcStartPosition + ((initialVelocity * time) + (0.5f * time * time) * Physics.gravity));
    }

    /// <summary>
    /// LineRendererの座標を更新
    /// </summary>
    /// <param name="index"></param>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    private void SetLineRendererPosition(int index, float startTime, float endTime, bool draw = true)
    {
        lineRenderers[index].SetPosition(0, GetArcPositionAtTime(startTime));
        lineRenderers[index].SetPosition(1, GetArcPositionAtTime(endTime));
        lineRenderers[index].enabled = draw;
    }

    /// <summary>
    /// LineRendererオブジェクトを作成
    /// </summary>
    private void CreateLineRendererObjects()
    {
        // 親オブジェクトを作り、LineRendererを持つ子オブジェクトを作る
        GameObject arcObjectsParent = new GameObject("ArcObject");

        lineRenderers = new LineRenderer[segmentCount];
        for (int i = 0; i < segmentCount; i++)
        {
            GameObject newObject = new GameObject("LineRenderer_" + i);
            newObject.transform.SetParent(arcObjectsParent.transform);
            lineRenderers[i] = newObject.AddComponent<LineRenderer>();

            
            lineRenderers[i].receiveShadows = false;
            lineRenderers[i].reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
            lineRenderers[i].lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
            lineRenderers[i].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            lineRenderers[i].material = arcMaterial;
            lineRenderers[i].startWidth = arcWidth;
            lineRenderers[i].endWidth = arcWidth;
            lineRenderers[i].numCapVertices = 5;
            lineRenderers[i].enabled = false;
        }
    }

    /// <summary>
    /// 指定座標にマーカーを表示
    /// </summary>
    /// <param name="position"></param>
    private void ShowPointer(Vector3 position)
    {
        pointerObject.transform.position = position;
        pointerObject.SetActive(true);
    }

    /// <summary>
    /// 2点間の線分で衝突判定し、衝突する時間を返す
    /// </summary>
    /// <returns>衝突した時間(してない場合はfloat.MaxValue)</returns>
    private float GetArcHitTime(float startTime, float endTime)
    {
        // Linecastする線分の始終点の座標
        Vector3 startPosition = GetArcPositionAtTime(startTime);
        Vector3 endPosition = GetArcPositionAtTime(endTime);

        // 衝突判定
        RaycastHit hitInfo;
        if (Physics.Linecast(startPosition, endPosition, out hitInfo))
        {
            // 衝突したColliderまでの距離から実際の衝突時間を算出
            float distance = Vector3.Distance(startPosition, endPosition);
            return startTime + (endTime - startTime) * (hitInfo.distance / distance);
        }
        return float.MaxValue;
    }
}
