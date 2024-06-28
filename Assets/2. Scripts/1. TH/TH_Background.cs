using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TH_Background : MonoBehaviour
{
    [SerializeField] private float ifPositonX;
    [SerializeField] private float transPositonX;
    void Update()
    {
        transform.position += Vector3.left * 3f * Time.deltaTime;
        if (transform.position.x < ifPositonX)
        {
            transform.position = new Vector3(transPositonX, transform.position.y, transform.position.z);
        }
    }
}
