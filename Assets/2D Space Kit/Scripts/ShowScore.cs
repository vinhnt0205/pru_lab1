using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    void Start()
    {
        text.text = "SCORE: " + ScoreManager.score;
        ScoreManager.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
