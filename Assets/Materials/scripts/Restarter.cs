﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}