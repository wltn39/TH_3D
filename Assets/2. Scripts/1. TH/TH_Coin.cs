using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TH_Coin : MonoBehaviour
{
    private float minY = -6f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
