using TMPro;
using UnityEngine;


public class TH_Enemy : MonoBehaviour
{
    public GameObject explosionFactory;

    private float minX = -10f;

    [SerializeField]
    private float hp = 1f;

    void Start()
    {

    }
    public void SetMoveSpeed(float moveSpeed)
    {
        TH_Database_Manager.Instance.EnemyMoveSpeed = moveSpeed;
    }

    void Update()
    {
        transform.position += Vector3.left * TH_Database_Manager.Instance.EnemyMoveSpeed * Time.deltaTime;
        if (transform.position.x < minX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            TH_Weapon weapon = other.gameObject.GetComponent<TH_Weapon>();
            hp -= weapon.damage;

            if (hp <= 0)
            {
                if (gameObject.tag == "Boss")
                {
                    TH_GameManager.instance.SetGameOver();
                }
                GameObject explosion = Instantiate(explosionFactory);
                explosion.transform.position = transform.position;

                Destroy(gameObject);
                Instantiate(TH_Database_Manager.Instance.coin, transform.position, Quaternion.identity);

            }
            Destroy(other.gameObject);
        }
    }
}
