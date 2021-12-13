using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;

    public int GetCurrentScore() 
    {
        return score;
    }

    public void ModifyScore(int modifier)
    {
        score += modifier;
        Mathf.Clamp(score, 0 , int.MaxValue);
        Debug.Log(score);
    }

    public void ResetScore() 
    {
        score = 0;
    }

}
