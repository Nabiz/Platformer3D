using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    [SerializeField] private Checkpoint[] checkpoints;

    void Start()
    {
        foreach (Checkpoint checkpoint in checkpoints)
        {
            checkpoint.SetCheckpointController(this);
        }
    }
    public void UnsetAllCheckpoints()
    {
        foreach (Checkpoint checkpoint in checkpoints)
        {
            checkpoint.UnsetChackpoint();
        }
    }
}
