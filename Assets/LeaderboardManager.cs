using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] int maxElements = 100;
    [SerializeField] int startElementIndex = 50;
    [SerializeField] RectTransform leaderboardEntryContainer;
    //[SerializeField] ScrollRect leaderboardScrollRect;
    [SerializeField] ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        //maxElements = a.GetComponent<Pool>().size;
        //Debug.Log(GetComponent<Pool>().size);
        SpawnLeaderboardElements();
        StartCoroutine(SetThePos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SetThePos()
    {
        yield return new WaitForEndOfFrame();

        float totalHeight = leaderboardEntryContainer.sizeDelta.y;
        float heightEachElement = totalHeight / maxElements;
        int correctedIndex = startElementIndex - 1;

        float containerYPos = heightEachElement * correctedIndex;
        leaderboardEntryContainer.anchoredPosition = new Vector2(0, containerYPos);
    }

    void SpawnLeaderboardElements()
    {
        //List<GameObject> leaderBoardEntries = objectPooler.GetAllPooledObjects(0);


        for (int i = 0; i < maxElements; i++)
        {
            GameObject element = objectPooler.GetPooledObject(1, i);
            element.name = "Entry "+ (i + 1);
            element.SetActive(true);
            element.GetComponent<LeaderBoardEntry>().SetLeaderboardValues(i+1, "User00" + i, 1000 - i, i);
        }
        //leaderBoardEntries[1].GetComponent<LeaderBoardEntry>().SetLeaderboardValues(9 + 1, "User00" + 9, 1000 - 9, 9);
    }
}
