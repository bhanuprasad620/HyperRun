using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public bool gameOver;

    public GameObject PausePanel;
    public GameObject Pause;
    public bool gamePaused;
    public TextMeshProUGUI PauseSymbol;

    public Image pauseButtonimage;
    public Sprite pauseSprite;
    public Sprite resumeSprite;
    public GameObject Iconimage;

    public int HighScore;
    public TextMeshProUGUI HighScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cointext.text =  coins.ToString();
        scoretext.text = "score :" + score;

        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        HighScoreText.text = "HighScore : " +HighScore;
    }

    public void AddCoin()
    {
        coins++;
        cointext.text = ":"+coins.ToString();

    }
    public void Doublecoin()
    {
        coins += 2;
        cointext.text = ":"+coins.ToString();
        if (coins >= 100)
        {
            coins += 8 ;
            cointext.text = ":" + coins.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver || gamePaused)
        return;

        if(score > HighScore)
        {
            HighScore = score;
            PlayerPrefs.SetInt("HighScore", HighScore);
            HighScoreText.text = "HighScore:" + HighScore;
        } 
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
        finalScoreText.text = ": " + score.ToString();
        finalCoinText.text = ": " + coins.ToString();
    }
    public void Restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        UpdateFinalUI();
        gameOverPanel.SetActive(true);
        gameOver=true;
        Debug.Log("game Over");
        Pause.SetActive(false);

        Iconimage.SetActive(false);
    }

    public void gamePause()
    {
        gamePaused = true;
        PausePanel.SetActive(true);
        pauseButtonimage.sprite = pauseSprite;
        Iconimage.SetActive(false);
    }
    public void resumeGame()
    {
        gamePaused = false;
        PausePanel.SetActive(false);
        pauseButtonimage.sprite = resumeSprite;
        Iconimage.SetActive(true);
    }
}
