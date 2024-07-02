using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Backtomenu();
        Joycontrol();
    }

    public void Startgame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exitgame()
    {
        Application.Quit();
    }
    public void Backtomenu()
    {
        if(Input.GetKey(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void Tutorial()
    {
        SceneManager.LoadScene(7);
    }

    void Joycontrol()
    {
        if(Input.GetKey(KeyCode.Joystick1Button1))
        {
            Startgame();
        }
        if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            Tutorial();
        }
        if (Input.GetKey(KeyCode.Joystick1Button2))
        {
            Exitgame();
        }
    }
}
