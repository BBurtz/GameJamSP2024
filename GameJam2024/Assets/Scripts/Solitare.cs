using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Solitare : MonoBehaviour
{
    public Sprite[] cardFaces;
    public GameObject[] bottomPos;
    public GameObject[] topPos;

    public List<string> Deck;

    public GameObject cardPrefab;

    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };


    public List<string>[] bottoms;
    public List<string>[] tops;

    private List<string> Bottom0 = new List<string>();
    private List<string> Bottom1 = new List<string>();
    private List<string> Bottom2 = new List<string>();
    private List<string> Bottom3 = new List<string>();
    private List<string> Bottom4 = new List<string>();
    private List<string> Bottom5 = new List<string>();
    private List<string> Bottom6 = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        bottoms = new List<string>[] { Bottom0, Bottom1, Bottom2, Bottom3, Bottom4, Bottom5, Bottom6};
        playCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playCards()
    {
        Deck = GenerateDeck();
        shuffle(Deck);
        SolitareSort();
        StartCoroutine(SolitaireDeal());
    }

    void shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    public static List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();
        foreach(string S in suits)
        {
            foreach(string V in values)
            {
                newDeck.Add(S + V);
            }
        }

        return newDeck;
    }

    IEnumerator SolitaireDeal()
    {
        for(int i = 0; i < 7; i++)
        {
            float yOffset = 0f;
            int layer = -9;
            foreach (string card in bottoms[i])
            {
                yield return new WaitForSeconds(0.01f);
                GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[i].transform.position.x, bottomPos[i].transform.position.y - yOffset, bottomPos[i].transform.position.z), Quaternion.identity, bottomPos[i].transform);
                newCard.name = card;

                if(card == bottoms[i][bottoms[i].Count - 1])
                {
                    newCard.GetComponent<Selectable>().faceUp = true;
                }
                newCard.GetComponent<SpriteRenderer>().sortingOrder = layer;

                layer++;
                yOffset += 0.3f;
            }
        }
    }

    void SolitareSort()
    {
        for (int i = 0; i < 7; i++)
        {
            for(int j = i; j < 7; j++)
            {
                bottoms[j].Add(Deck.Last<string>());
                Deck.RemoveAt(Deck.Count-1);
            }
        }
    }
}
