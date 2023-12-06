using UnityEngine;
using TMPro;
using System.Collections;

public class GemCollection : MonoBehaviour
{
    private int num = 0;
    private AudioSource source;
    [SerializeField] TextMeshProUGUI textMeshPro;
    private void Awake()
    {
        textMeshPro.text = PlayerPrefs.GetInt("Diamonds", 0).ToString();
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        source.Play();
        num++;
        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds", 0) + 1);
        textMeshPro.text = PlayerPrefs.GetInt("Diamonds", 0).ToString();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        Destroy(gameObject);
    }
    IEnumerator SoundPlaying()
    {
        yield return new WaitUntil(() => !source.isPlaying);
        
    }
    private void OnDestroy()
    {
        StartCoroutine(SoundPlaying());
    }

}
