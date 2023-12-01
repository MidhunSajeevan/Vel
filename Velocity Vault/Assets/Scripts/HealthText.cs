using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    public Vector3 moveSpeed = new Vector3(0, 75, 0);
    public RectTransform textTransform;
    public TextMeshProUGUI textMeshPro;
    private float TimeElapsed = 0;
    private float TimeToFade = 2f;
    public Color startColor;
   
    // Update is called once per frame
    void Update()
    {
        textTransform.position += moveSpeed*Time.deltaTime;
        TimeElapsed += Time.deltaTime;

        if(TimeElapsed < TimeToFade )
        {
            float alpha= startColor.a * (1 - (TimeElapsed / TimeToFade));
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
        }
        else
        { 
                Destroy(gameObject);
          
            
        }
       
    }
}
