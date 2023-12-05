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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _animator.SetTrigger("Fade_Out");
        }
    }

    public void Loadscene()
    {
        SceneManager.LoadScene(_scene);
    }
}
