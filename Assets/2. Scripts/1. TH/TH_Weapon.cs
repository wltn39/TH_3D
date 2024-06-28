using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TH_Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10; // 미사일 스피드

    public float damage = 1f;

    // Start is called before the first frame update (처음 한번만 호출)
    void Start()
    {
        Destroy(gameObject, 2f); // 게임오브젝트를 1초 뒤 없애줘 
    }

    void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }
}
