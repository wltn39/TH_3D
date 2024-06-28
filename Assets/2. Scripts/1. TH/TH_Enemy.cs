using TMPro;
using UnityEngine;


public class TH_Enemy : MonoBehaviour
{
    public GameObject explosionFactory;

    [SerializeField]
    private float moveSpeed = 5f;
    private float minY = -6f;

    [SerializeField]
    private float hp = 1f;


    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;

    }

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
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
