using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool _isFinished = false;
    public Button _nextButton;
    public UnityEvent GameFinished;

   public bool IsFinished
    {
        get
        {
            return _isFinished;
        }
        set { _isFinished = value; }
    }
    private void Awake()
    {
        IsFinished = false;
        _nextButton.interactable = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     

      
        if (collision.gameObject.CompareTag("Player"))
        {
            //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            _nextButton.interactable= true;
            PlayerPrefs.SetInt("Unlocklevel", SceneManager.GetActiveScene().buildIndex + 1);
            IsFinished = true;
            GameFinished?.Invoke();
        }
    }
    public void Play()
    {


        int unlockLevel = PlayerPrefs.GetInt("Unlocklevel", 1);
        SceneManager.LoadScene(unlockLevel);

    }
    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
   
       SceneManager.LoadScene("MainMenu");
    }
    public void NextLevel()
    { 
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Pouse(int num)
    {
        Time.timeScale = num;
    }
    public void Levels()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
