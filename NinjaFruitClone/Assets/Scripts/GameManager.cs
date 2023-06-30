using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text comboText;
    public int maxHeath = 100;
    public int currentHeath;
    public HeathBar heathBar;

    private int score;


    private void Start()
    {
        NewGame();
        currentHeath = maxHeath;
        heathBar.SetMaxSlider(maxHeath);
    }


    private void NewGame()
    {
        score = 0; 
        scoreText.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void TakeDamage(int damage)
    {
        currentHeath -= damage; 
        heathBar.SetSlider(currentHeath);
    }

    private void GetCombo(int combo, GameObject gameObject)
    {
        comboText.text = "Combo " + combo.ToString();
        comboText.transform.position = gameObject.transform.position;
    }
}
