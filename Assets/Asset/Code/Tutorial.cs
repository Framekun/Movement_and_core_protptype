using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private int _sceneNumber;
  public void Loadscene()
    {
        SceneManager.LoadScene(_sceneNumber);
    }
}
