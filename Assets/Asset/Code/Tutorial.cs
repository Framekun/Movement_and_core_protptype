using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private int _sceneNumber;
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Joystick1Button1))
        {
            Loadscene();
        }
    }
    public void Loadscene()
    {
        SceneManager.LoadScene(_sceneNumber);
    }
}
