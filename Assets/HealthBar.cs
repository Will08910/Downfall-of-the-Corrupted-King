using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public GameObject Heart;
    public GameObject Skull;

    void Start()
    {
        Skull.SetActive(false);
        Heart.SetActive(true);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        if (health == 0)
        {
            Heart.SetActive(false);
            Skull.SetActive(true); 
        }
    }
}