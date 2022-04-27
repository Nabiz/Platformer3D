using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{


    private bool isCurrent = false;
    private Vector3 _flagOffPos = new Vector3(0, 1.8f, 0);
    private Vector3 _flagOffScale = new Vector3(2.0f, -2.0f, 2.0f);
    private Vector3 _flagOnPos = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 _flagOnScale = new Vector3(2.0f, 2.0f, 2.0f);

    [SerializeField] private GameObject flag;
    private CheckpointController _checkpointController;
    
    public void SetCheckpointController(CheckpointController checkpointController)
    {
        _checkpointController = checkpointController;
    }

    private void Start()
    {
        isCurrent = false;
        flag.transform.localPosition = _flagOffPos;
        flag.transform.localScale = _flagOffScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isCurrent)
            {
                _checkpointController.UnsetAllCheckpoints();
                isCurrent = true;
                flag.transform.localPosition = _flagOnPos;
                flag.transform.localScale = _flagOnScale;
                other.GetComponent<PlayerController>().ChangeSpawnPoint(transform.position);
            }
        }
    }

    public void UnsetChackpoint()
    {
        isCurrent = false;
        flag.transform.localPosition = _flagOffPos;
        flag.transform.localScale = _flagOffScale;
    }
}
