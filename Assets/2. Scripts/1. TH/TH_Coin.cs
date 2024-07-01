using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TH_Coin : MonoBehaviour
{
    public Transform shootTransform;

    private float destroyTime = 5f; // 오브젝트가 사라질 시간 (초)

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        Invoke("DestroyObject", destroyTime);
    }

    // 오브젝트를 파괴하는 메서드
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
