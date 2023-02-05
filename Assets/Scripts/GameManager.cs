using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;

    public Text scoreText;
   
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject getReady;
    public GameObject resetButton;

    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    public void Play()
    {
        
        playButton.SetActive(false);
        resetButton.SetActive(false);
        getReady.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Bullets[] bullets = FindObjectsOfType<Bullets>();
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(pipes[i].gameObject);
            Destroy(bullets[i].gameObject);
        }
    }
    
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    /* Tek kjo pjese Jane perfshir disa metoda te cilat e bejne funksionalizimin e shfaqjes se User Interface-it
     (GameOver dhe PlayButton) po ashtu edhe pause nese karakteri godet ndonje Object */

    public void GameOver()
    {
        gameOver.SetActive(true);
        resetButton.SetActive(true);    

        Pause();
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
