using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;

    static ScoreKeeper instance;

    private void Awake() 
    {
        ManageSingleton();    
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

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
