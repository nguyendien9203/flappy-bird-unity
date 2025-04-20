using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public TMP_Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;

    private void Awake()
    {
        // Đặt giới hạn khung hình để game mượt mà hơn
        Application.targetFrameRate = 60;

        // Tạm dưng game khi khởi động, chưa cho người chơi chơi ngay
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        // Thời gian chạy lại 
        Time.timeScale = 1f;
        player.enabled = true;

        // Tìm và xóa lại các pipes còn lại trên màn hình để bắt đầu lại từ đầu
        Pipes[] pipes = FindObjectsByType<Pipes>(FindObjectsSortMode.None); 

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        // Dừng toàn bộ thời gian của game (mọi thứ đứng yên)
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
