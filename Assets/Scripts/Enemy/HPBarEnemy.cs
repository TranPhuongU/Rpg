using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HPBarEnemy : MonoBehaviour
{
    public Slider Slider;
    public Color low;
    public Color Hight;
    public Vector3 Offset;

    public void SetHealth (float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health; 
        Slider.maxValue = maxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low,Hight,Slider.normalizedValue);
    }
    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);

    }
}
