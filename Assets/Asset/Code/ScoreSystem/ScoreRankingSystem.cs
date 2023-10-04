using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRankingSystem : MonoBehaviour
{
    [SerializeField] int RankARequirement;
    [SerializeField] int RankBRequirement;
    [SerializeField] int RankCRequirement;
    [SerializeField] int RankDRequirement;
    int ScoreRecieved;
    void Start()
    {
        
    }


    void Update()
    {
        int ScoreRecieved = PlayerPrefs.GetInt("ScoreHolder");
        if (RankDRequirement > ScoreRecieved)
        {

        }
        else if (RankDRequirement < ScoreRecieved && RankCRequirement > ScoreRecieved)
        {

        }
        else if (RankCRequirement < ScoreRecieved && RankBRequirement > ScoreRecieved)
        {

        }
        else if (RankBRequirement < ScoreRecieved && RankARequirement > ScoreRecieved)
        {

        }
        else if (RankARequirement < ScoreRecieved)
        {

        }
        else
        {
            print("HEY YOU FORGOT TO INSERT SCORES");
        }
    }
}
