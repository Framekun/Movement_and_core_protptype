using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallcolorcode : MonoBehaviour
{
    public Hitboxcode hitboxdected;
    [SerializeField] public bool redType;
    [SerializeField] public bool blueType;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        hitboxdected = other.GetComponent<Hitboxcode>();

        if(hitboxdected != null ) 
        { 
            if(hitboxdected.redattack == true)
            {
                if(redType== true) 
                {
                    print("Reddected");
                    Destroy(gameObject);
                }
            }

            if (hitboxdected.Blueattack == true)
            {
                if(blueType== true)
                {
                    print("Bluedected");
                    Destroy(gameObject);
                }
            }
        }
    }
}
