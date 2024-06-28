using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TH_ClonePrefab : MonoBehaviour
{
    public GameObject[] weapons;
    private int weaponIndex = 0;
    [SerializeField]
    private Transform shootTransform;
    private float lastShotTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if (TH_GameManager.instance.isGameOver == false && gameObject.activeSelf)
        {
            Shoot();
        }
    }


    void Shoot()
    {
        if (Time.time - lastShotTime > TH_Database_Manager.Instance.cloneShootInterval)
        {
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
        {
            gameObject.SetActive(false);
        }
    }
}
