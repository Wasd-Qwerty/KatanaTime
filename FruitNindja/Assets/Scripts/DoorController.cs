using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
