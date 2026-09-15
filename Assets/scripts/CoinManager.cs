using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    int coins = 0;
    public TextMeshProUGUI cointext;

    int score = 0;
    public TextMeshProUGUI scoretext;
    float scoreTimer;

    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI finalCoinText;
    public GameObject gameOverPanel;
    bool gameOver;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cointext.text = "coin:"+ coins;
        scoretext.text = "score :" + score;
    }

    public void AddCoin()
    {
        coins++;
        cointext.text = "coin:" + coins;

    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        return;
        scoreTimer += Time.deltaTime;

        if(scoreTimer >= 0.5)
        {
            score++;
            scoreTimer = 0;

            scoretext.text = "score :" + score;
        }
        if(score >= 50)
        {
            scoreTimer += Time.deltaTime*2;
        }
        if(score >= 250)
        {
            scoreTimer += Time.deltaTime*8;
        }
        
    }
    public void UpdateFinalUI()
    {
        finalScoreText.text = "Score: " + score;
        finalCoinText.text = "Coins: " + coins;
    }
    public void GameOver()
    {
        UpdateFinalUI();
        gameOverPanel.SetActive(true);
        gameOver=true;
    }
}
