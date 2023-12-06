using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameClearGameFailRNG : MonoBehaviour
{
    [SerializeField] private GameObject[] NumberStuff;
    private int LuckyNumber;
    private GameObject LuckyObject;
    // Start is called before the first frame update
    void Start()
    {
        LuckyNumber = Random.Range(0, (NumberStuff.Length));

        Debug.Log(LuckyNumber);
        Debug.Log(NumberStuff.Length);
        for (int i = 0; i < NumberStuff.Length; i++)
        {
            if (i == LuckyNumber)
            {
                NumberStuff[i].SetActive(true);
            }
            else
            {
                NumberStuff[i].SetActive(false);
            }
        }
   
    }

   
}
