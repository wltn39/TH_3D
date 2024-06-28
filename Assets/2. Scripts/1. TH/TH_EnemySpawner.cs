using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TH_EnemySpawner : MonoBehaviour
{
    // private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f };       

    // Start is called before the first frame update
    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }

    public void StopEnemyRoutine()
    {
        StopCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);

        float moveSpeed = 5f;
        int spawnCount = 0;
        int enemyIndex = 0;

        while (true)
        {
            foreach (float posX in TH_Database_Manager.Instance.arrPosX)
            {
                int index = Random.Range(0, TH_Database_Manager.Instance.enemies.Length);
                SpawnEnemy(posX, index, moveSpeed);
            }
            spawnCount += 1;
            if (spawnCount % 3 == 0)
            {
                enemyIndex += 1;
                moveSpeed += 1;
            }

            if (enemyIndex >= TH_Database_Manager.Instance.enemies.Length)
            {
                SpawnBoss();
                enemyIndex = 0;
                moveSpeed = 5f;
            }

            yield return new WaitForSeconds(TH_Database_Manager.Instance.SpawnInterval);
        }
    }
    void SpawnEnemy(float posX, int index, float moveSpeed)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
        GameObject enemyObject = Instantiate(TH_Database_Manager.Instance.enemies[index], spawnPos, Quaternion.identity);
        TH_Enemy enemy = enemyObject.GetComponent<TH_Enemy>(); // Enemy 클래스 가져와서 객체로 만들기
        enemy.SetMoveSpeed(moveSpeed);

    }

    void SpawnBoss()
    {
        Instantiate(TH_Database_Manager.Instance.Boss, transform.position, Quaternion.identity);
    }
}
