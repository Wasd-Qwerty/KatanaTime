using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public string sceneName;

    public void Occurrence()
    {
        GetComponent<Animator>().SetTrigger("occurrence");
    }
    public void StartLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
