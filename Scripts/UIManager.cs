using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public BallMovement ballMovement;
    public CameraMovement cameraMovement;

    public GameObject GameOverPnl;
    public GameObject topPnl;
   
    public GameManager gameManager;
    public Text recordtxt;

    void Update()
    {
        GameOverPanel();
    }

    public void StartGame()
    {
        ballMovement.StartGame = true;
        cameraMovement.StartGame = true;
    }

    public void GameOverPanel()
    {
        if (ballMovement.GameIsOver == true)
        {
            GameOverPnl.SetActive(true);
            topPnl.SetActive(false);
            recordtxt.text = "RECORD : " + gameManager.Record.ToString();
            if (gameManager.Record > gameManager.HighRecord)
                recordtxt.text = "BEST RECORD! : " + gameManager.Record.ToString();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    
    public void HomePage()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        ballMovement.StartGame = false;
        cameraMovement.StartGame = false;
    }

    public void Play()
    {
        ballMovement.PlayAfterPause();
        ballMovement.StartGame = true;
        cameraMovement.PlayAfterPause();
        cameraMovement.StartGame = true;
    }

    public void Quit()
    {
        Application.Quit();
    }   
}
