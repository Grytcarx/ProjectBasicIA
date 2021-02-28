using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrincipalScreen : MonoBehaviour
{
    Slider level;
    Text levelText;

    private void Start()
    {
        level = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Lvl").GetComponent<Slider>();
        levelText = GameObject.FindGameObjectWithTag("Canvas").transform.Find("DificultadTexto").GetComponent<Text>();

    }

    public void IrAGame()
    {
        PlayerPrefs.SetFloat("EnemyLevel", level.value);
        SceneManager.LoadScene("Game");

    }


    public void OnChangeSlider()
    {
        levelText.text = level.value.ToString();

    }
}
