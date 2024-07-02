using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public Animator _animator;
    [SerializeField] private int _scene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            _animator.SetTrigger("Fade_Out");
        }
    }

    public void Loadscene()
    {
        SceneManager.LoadScene(_scene);
    }
}
