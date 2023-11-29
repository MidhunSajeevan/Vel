using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public GameObject healthTextPrefab;

    public Canvas GameCanvas;
    private void Awake()
    {
        GameCanvas = FindObjectOfType<Canvas>();
    }
    private void OnEnable()
    {
        CharectorEvents.charectorDamaged += CharectorTookDamage;
        CharectorEvents.charectorHealed += CharectorHealed;
    }
    private void OnDisable()
    {
        CharectorEvents.charectorDamaged += CharectorTookDamage;
        CharectorEvents.charectorHealed += CharectorHealed;
    }
    public void CharectorTookDamage(GameObject charector, int damage)
    {
        Vector3 SpownPosition = Camera.main.WorldToScreenPoint(charector.transform.position);

        TMP_Text tMP_Text = Instantiate(damageTextPrefab,SpownPosition ,Quaternion.identity,GameCanvas.transform)
            .GetComponent<TMP_Text>();
        tMP_Text.text = damage.ToString();
    }

    public void CharectorHealed(GameObject charector, int healthrestored)
    {
        Vector3 SpownPosition = Camera.main.WorldToScreenPoint(charector.transform.position);

        TMP_Text tMP_Text = Instantiate(healthTextPrefab, SpownPosition, Quaternion.identity, GameCanvas.transform)
            .GetComponent<TMP_Text>();
        tMP_Text.text = healthrestored.ToString();
    }
}
