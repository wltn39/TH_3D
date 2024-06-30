using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TH_Player : MonoBehaviour
{
    public GameObject explosionFactory;
    public Transform shootTransform;

    public GameObject[] weapons;
    private int weaponIndex = 0;

    private float lastShotTime = 0f;
    private Vector3 minBounds = new Vector3(-8.5f, -7.6f, -1f);  // 최소 좌표 경계
    private Vector3 maxBounds = new Vector3(8f, 2f, 0f);  // 최대 좌표 경계

    // clone 
    private GameObject leftClone;
    private GameObject rightClone;
    private Vector3 leftCloneOffset = new Vector3(-0.5f, -1f, -1f);
    private Vector3 rightCloneOffset = new Vector3(0.5f, -1f, -1f);

    void Awake()
    {
        // leftClone = Instantiate(TH_Database_Manager.Instance.clonePrefab, transform.position + leftCloneOffset, Quaternion.identity);
        // leftClone.SetActive(false);
        // rightClone = Instantiate(TH_Database_Manager.Instance.clonePrefab, transform.position + rightCloneOffset, Quaternion.identity);
        // rightClone.SetActive(false);
    }

    void Update()
    {
        Move();
        // 플레이어 위치를 경계 안에 제한
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y),
            Mathf.Clamp(transform.position.z, minBounds.z, maxBounds.z)
        );
        if (TH_GameManager.instance.isGameOver == false)
        {
            Shoot();
            SyncClones();
        }
    }

    void Move()
    {

        float move_UpDown = 0f;
        float move_LeftRight = 0f;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            move_UpDown = 1f; // 위로 이동
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            move_UpDown = -1f; // 아래 이동
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            move_LeftRight = -1f; // 왼쪽 이동
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            move_LeftRight = 1f; // 오른쪽 이동
        }

        // 입력값에 따라 플레이어 이동
        Vector3 move = new Vector3(move_LeftRight, move_UpDown, 0);
        transform.position += move * TH_Database_Manager.Instance.playerMoveSpeed * Time.deltaTime;


        // 마우스 or 터치 이동 (태블릿 테스트용)햣
        // Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        // transform.position = new Vector3(toX, transform.position.y, transform.position.z);
    }

    void Shoot()
    {
        if (Time.time - lastShotTime > TH_Database_Manager.Instance.shootInterval)
        {
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
        {
            TH_GameManager.instance.SetGameOver();
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            TH_GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }
    public void Upgrade()
    {
        weaponIndex += 1;
        if (weaponIndex >= weapons.Length)
        {
            weaponIndex = weapons.Length - 1;
        }
        setClone();
    }
    void SyncClones()
    {
        // leftClone.transform.position = transform.position + new Vector3(-0.5f, -1f, 0);
        // rightClone.transform.position = transform.position + new Vector3(0.5f, -1f, 0);
    }

    void setClone()
    {
        if (leftClone.activeSelf && rightClone.activeSelf) { return; }
        if (!leftClone.activeSelf && !rightClone.activeSelf)
        {
            leftClone.SetActive(true);
            return;
        }
        if (leftClone.activeSelf && !rightClone.activeSelf)
        {
            rightClone.SetActive(true);
            return;
        }
        if (rightClone.activeSelf && !leftClone.activeSelf)
        {
            leftClone.SetActive(true);
            return;
        }
    }

}

