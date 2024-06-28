using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TH_Database_Manager : ScriptableObject
{
    public static TH_Database_Manager Instance;

    [Header("플레이어")]
    public float playerMoveSpeed = 1f; // 
    public float shootInterval; // 미사일 발사속도
    public GameObject clonePrefab;
    public float cloneShootInterval; // 발사간격

    [Header("적")]
    public GameObject[] enemies;
    public GameObject Boss;
    public float SpawnInterval = 3f; // 적 출현 속도
    public float[] arrPosX = { -2.4f, -1.5f, -0.6f, 0.3f, 1.2f, 2.1f }; // 적 출현 좌표

    [Header("아이템")]
    public GameObject coin;

    public void Init_Func()
    {
        Instance = this;
    }


}
