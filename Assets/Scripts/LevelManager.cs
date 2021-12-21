using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float SceneLoadDelay = 1f;
   public void LoadGame()
   {
       Debug.Log("Game");
       SceneManager.LoadScene(1);
   }

   public void LoadMainMenu()
   {
       Debug.Log("Menu");
       SceneManager.LoadScene(0);
   }

   public void LoadGameOver() 
   {
       Debug.Log("Game Over");
       StartCoroutine(WaitAndLoad( 2, SceneLoadDelay));
   }

   public void QuitGame() 
   {
       Debug.Log("Quit");
       Application.Quit();
   }

   IEnumerator WaitAndLoad(int SceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneIndex);
    }
}
