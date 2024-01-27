using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor2Behavior : MonoBehaviour
{
    [Header("VIM Message Prefabs")]
    [SerializeField] private List<GameObject> earlyVIM = new List<GameObject>();
    [SerializeField] private List<GameObject> midVIM = new List<GameObject>();
    [SerializeField] private List<GameObject> endVIM = new List<GameObject>();
    private GameObject selectedVIM;
    private Vector2 VIMLocation;


    private void OnEnable()
    {
        GameManager.StartVIM += StartVIM;
    }
    private void OnDisable()
    {
        GameManager.StartVIM -= StartVIM;
    }

    private void StartVIM()
    {
        StartCoroutine(VIMTimer());
    }

    private void SpawnVIM()
    {
        SelectVIMMessage();
        SelectVIMLocation();
        Instantiate(selectedVIM, VIMLocation, transform.rotation);
    }

    private void SelectVIMMessage()
    {
        if(GameManager.GamePhase == 1 && earlyVIM[0] != null)
        {
            selectedVIM = earlyVIM[Random.Range(0, earlyVIM.Count - 1)];
        }
        else if (GameManager.GamePhase == 2 && midVIM[0] != null)
        {
            selectedVIM = midVIM[Random.Range(0, midVIM.Count - 1)];
        }
        else if (GameManager.GamePhase == 3 && endVIM[0] != null)
        {
            selectedVIM = endVIM[Random.Range(0, endVIM.Count - 1)];
        }
    }

    private void SelectVIMLocation()
    {
        VIMLocation = new Vector2(Random.Range(-13.25f, -9.63f), Random.Range(0.85f, -1.92f));
    }

    IEnumerator VIMTimer()
    {
        while(true)
        {
            SpawnVIM();
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
    }
}
