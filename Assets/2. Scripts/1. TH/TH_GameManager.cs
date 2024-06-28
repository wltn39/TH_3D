using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TH_GameManager : MonoBehaviour
{
    [SerializeField] private TH_Database_Manager database_Manager = null;
    public static TH_GameManager instance = null;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private TextMeshProUGUI PanelText;
    private int coin = 0;


    [HideInInspector]
    public bool isGameOver = false;
    private void Awake()
    {
        this.database_Manager.Init_Func();

        if (instance == null)
        {
            instance = this;
        }
    }
    public void IncreaseCoin()
    {
        coin += 1;
        text.SetText(coin.ToString());
        PanelText.SetText(coin.ToString());

        if (coin % 5 == 0)
        {
            TH_Player player = FindObjectOfType<TH_Player>();
            if (player != null)
            {
                player.Upgrade();
            }
        }
    }

    public void SetGameOver()
    {
        isGameOver = true;
        TH_EnemySpawner enemySpawner = FindObjectOfType<TH_EnemySpawner>();
        if (enemySpawner != null)
        {
            enemySpawner.StopEnemyRoutine();
        }

        Invoke("ShowGameOverPanel", 1f);
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("TH_GameScene");
    }
}
