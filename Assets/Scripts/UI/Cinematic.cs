using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour
{
    int number = 0;
    float secondsCounter = 0;
    float secondsToCount = 1;
    public Text cinematic;
    

    // Update is called once per frame
    void Update()
    {
        secondsCounter += Time.deltaTime;
        if (secondsCounter >= secondsToCount)
        {
            
            secondsCounter = 0;
            number++;
        }
        cinematic.text = number.ToString();

        if (number == 5)
        {
            SceneManager.LoadScene("PrincipalScreen",LoadSceneMode.Single);
        }
    }
}
