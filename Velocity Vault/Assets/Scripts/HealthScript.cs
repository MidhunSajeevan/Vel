using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class HealthScriptForBar : MonoBehaviour
{
    private Slider _slider;
    private Damagable damagable;
    public Gradient gradient;
    void Start()
    {
        _slider = GetComponent<Slider>();

        // Assuming damagable is on the same GameObject as this script
        damagable = GetComponent<Damagable>();
        
        if (damagable != null)
        {
            damagable.onTakeDamage.AddListener(TakeDamage);
        }
    }

    public void TakeDamage(int damageAmount)
    {

        _slider.value -= damageAmount;
        UpdateHealthColor();
    }
    void UpdateHealthColor()
    {
        float healthPercentage = _slider.value / _slider.maxValue;
        Color gradientColor = gradient.Evaluate(healthPercentage);
        _slider.fillRect.GetComponentInChildren<Image>().color = gradientColor;
    }
}
