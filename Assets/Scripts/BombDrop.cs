using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrop : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] float TimeBeforeDropFirstBomb = 0.1f;
    [SerializeField] float TimeBetweenBombDrops = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropBomb());
    }

    IEnumerator DropBomb() 
    {
        yield return new WaitForSeconds(TimeBeforeDropFirstBomb);
        int numOfBombs = 0;
        while(numOfBombs < 4)
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            numOfBombs +=1;
            yield return new WaitForSeconds(TimeBetweenBombDrops);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
