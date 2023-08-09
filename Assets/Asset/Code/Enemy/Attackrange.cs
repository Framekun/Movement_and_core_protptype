using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackrange : MonoBehaviour
{
    [SerializeField] Enemycode enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.Canattack= true;
        }
    }
}
