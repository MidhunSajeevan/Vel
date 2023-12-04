using TMPro;
using UnityEngine;

public class AchivementsDetails : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _diamond;
    [SerializeField]
    private TextMeshProUGUI _timeTaken;
    [SerializeField]
    private TextMeshProUGUI _lifeRemaining;
  
    private void OnEnable()
    {
            _diamond.text = PlayerPrefs.GetInt("Diamonds",0).ToString();
            float time = PlayerPrefs.GetFloat("HighScore");
            float minuets = Mathf.Floor(time / 60); 
            float seconds = Mathf.Floor(time % 60);
            string currentTime = string.Format("{00:00}:{1:00}", minuets, seconds);
            _timeTaken.text = currentTime;  
            _lifeRemaining.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Damagable>().Health.ToString();
          
    }


}
