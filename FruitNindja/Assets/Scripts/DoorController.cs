using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private Material _level1;
    [SerializeField] private Material _level2;
    [SerializeField] private Material _level3;
    [SerializeField] private GameObject _background; 
    
    public void Occurrence()
    {
        if (sceneName == "Level")
        {
            _background.GetComponent<MeshRenderer>().material = _level1;
        }
        else if (sceneName == "Level2")
        {
            _background.GetComponent<MeshRenderer>().material = _level2;
        }
        else if (sceneName == "Level3")
        {
            _background.GetComponent<MeshRenderer>().material = _level3;
        }
        GetComponent<Animator>().SetTrigger("occurrence");
    }
    public void StartLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
