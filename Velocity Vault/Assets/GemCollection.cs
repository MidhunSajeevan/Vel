using UnityEngine;
using TMPro;

public class GemCollection : MonoBehaviour
{
    private int num = 0;
    [SerializeField] TextMeshProUGUI textMeshPro;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        num++;
        textMeshPro.text = num.ToString();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
