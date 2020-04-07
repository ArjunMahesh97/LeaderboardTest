using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoardEntry : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI rankText, userText, winsText, lossesText, WRText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLeaderboardValues(int rank,string user,int wins,int losses)
    {
        //SetupComponents();

        float total = wins + losses;
        float percent = (float)(wins / total) * 100;
        double WR = System.Math.Round(percent, 1);

        rankText.text = rank.ToString();
        userText.text = user;
        winsText.text = wins.ToString();
        lossesText.text = losses.ToString();
        WRText.text = WR.ToString();
    }
}
