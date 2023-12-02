
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("Unlocklevel", SceneManager.GetActiveScene().buildIndex+1);
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
    public void Play()
    {


        int unlockLevel = PlayerPrefs.GetInt("Unlocklevel", 1);
        SceneManager.LoadScene(unlockLevel);

    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
   
       SceneManager.LoadScene("MainMenu");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
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
