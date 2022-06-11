using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickEscape : MonoBehaviour
{

    [SerializeField] PlayerController playerController;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CheckpointController.ClearCheckpointList();
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetButtonDown("Reset"))
        {
            playerController.Spawn();
        }
    }
}
