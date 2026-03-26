using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Score;

    private void OnEnable()
    {
        Score.text ="Score : " + PlayerPrefs.GetFloat("Score").ToString(".00");
    }
}
