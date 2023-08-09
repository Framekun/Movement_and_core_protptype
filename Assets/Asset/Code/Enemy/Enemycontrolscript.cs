using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontrolscript : MonoBehaviour
{
    [SerializeField] private List <newEnemy> enemycodeList;
    [SerializeField] private Battlemode battlemode;
    public bool clear = false;

    private void Awake()
    { 
        foreach (var enemy in enemycodeList)
        {
            enemy.SetController(this);
        }
    }

    public void HandleEnemyDeath(newEnemy deadEnemy)
    {
        enemycodeList.Remove(deadEnemy);
        if (enemycodeList.Count <= 0)
        {
            // do something
            clear = true;
            battlemode.Battlemodeactive = false;
            Debug.Log("Clear");
            
        }
    }
}
