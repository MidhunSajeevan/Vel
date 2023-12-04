using UnityEngine;
using TMPro;

public class GemCollection : MonoBehaviour
{
    private int num = 0;
    
    [SerializeField] TextMeshProUGUI textMeshPro;
    private void Awake()
    {
        textMeshPro.text = PlayerPrefs.GetInt("Diamonds", 0).ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        num++;
        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds", 0) + 1);
        textMeshPro.text = PlayerPrefs.GetInt("Diamonds", 0).ToString();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
