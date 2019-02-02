using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerTroll : MonoBehaviour
{
    private static bool cameraExists;
    public string actualLevelName;

    private void Start()
    {
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        actualLevelName = SceneManager.GetActiveScene().name;

        /* Let's not do that, because bugs
         * if (Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<LoadNewScene>().LoadNewLevel(actualLevelName);
        }*/ 
    }
}