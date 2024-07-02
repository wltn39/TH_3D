using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TH_Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10; // 미사일 스피드

    public float damage = 1f;

    void Start()
    {
        Destroy(gameObject, 2.5f);
    }

    void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }
}
