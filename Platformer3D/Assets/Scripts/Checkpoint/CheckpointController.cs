using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private static List<Checkpoint> checkpoints = new List<Checkpoint>();

    public static void AddCheckpointToList(Checkpoint checkpoint)
    {
        checkpoints.Add(checkpoint);
    }
    public static void UnsetAllCheckpoints()
    {
        foreach (Checkpoint checkpoint in checkpoints)
        {
            checkpoint.UnsetChackpoint();
        }
    }

    public static void ClearCheckpointList()
    {
        checkpoints.Clear();
    }
}
