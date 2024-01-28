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

    [SerializeField] private GameObject YapsterPrefab;
    [SerializeField] private GameObject UnstablePrefab;
    [SerializeField] private GameObject SpotItPrefab;


    private void OnEnable()
    {
        GameManager.StartVIM += StartVIM;
        GameManager.Yapster += SpawnYap;
        GameManager.Unstable += SpawnUnstable;
        GameManager.SpotIt += SpawnSpotIt;
    }
    private void OnDisable()
    {
        GameManager.StartVIM -= StartVIM;
        GameManager.Yapster -= SpawnYap;
        GameManager.Unstable -= SpawnUnstable;
        GameManager.SpotIt -= SpawnSpotIt;
    }

    //VIM
    private void StartVIM()
    {
        StartCoroutine(VIMTimer());
    }
    private void SpawnVIM()
    {
        SelectVIMMessage();
        SelectVIMLocation();
        Instantiate(selectedVIM, VIMLocation, transform.rotation);
        AudioManager.Instance.Play("VIMPopUp");
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
            yield return new WaitForSeconds(Random.Range( 10, 20));
        }
    }

    //Malware Spawns
    private void SpawnYap()
    {
        AudioManager.Instance.Play("MalwarePopUp");
        Vector2 YapSpawnPt = new Vector2(Random.Range(-13.77f, -9.38f), Random.Range(-1.4f, 0f));
        Instantiate(YapsterPrefab, YapSpawnPt, transform.rotation);
    }

    private void SpawnUnstable()
    {
        AudioManager.Instance.Play("MalwarePopUp");
        Vector2 UnstableSpawnPt = new Vector2(Random.Range(-12.38f, -10.56f), Random.Range(-2.14f, 1f));
        Instantiate(UnstablePrefab, UnstableSpawnPt, transform.rotation);
    }

    private void SpawnSpotIt()
    {
        AudioManager.Instance.Play("MalwarePopUp");
        Vector2 UnstableSpawnPt = new Vector2(Random.Range(-12.46f, -10.48f), Random.Range(-1.34f, 0.19f));
        Instantiate(SpotItPrefab, UnstableSpawnPt, transform.rotation);
    }
}
