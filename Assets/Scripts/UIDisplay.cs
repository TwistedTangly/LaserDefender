using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    Slider healthSlider;
    ScoreKeeper ScoreKeeper;
    Health health;
    
    private void Awake() {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        healthSlider = FindObjectOfType<Slider>();
        ScoreKeeper = FindObjectOfType<ScoreKeeper>();
        health = FindObjectOfType<Health>();
    }
    void Start()
    {
        healthSlider.maxValue = health.GetHealth();
        healthSlider.value = health.GetHealth();
    }


    void Update()
    {
        scoreText.text = ScoreKeeper.GetCurrentScore().ToString("000000000");
        healthSlider.value = health.GetHealth();
    }
}
