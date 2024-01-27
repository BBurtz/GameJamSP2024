using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solitare : MonoBehaviour
{
    public List<int> cardsShuffled;
    public List<GameObject> SolitarePiles;

    private void Awake()
    {
        List<int> allRemainingNumbers = new List<int>();
        for (int i = 0; i <= 51; i++)
        {
            allRemainingNumbers.Add(i);
        }
        for (int i = 0; i <= 51; i++)
        {
            int newShuffle = (int)(Random.Range(0, allRemainingNumbers.Count));
            cardsShuffled.Add(allRemainingNumbers[newShuffle]);
            allRemainingNumbers.RemoveAt(newShuffle);
        }

        for(int i = 0; i <= 6; i++)
        {
            //place the final card of each row, reveal it
           for(int j = i + 1; j <= 6; j++)
           {
                //place unreveild cards in all the remaining rows than repeat
           }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
