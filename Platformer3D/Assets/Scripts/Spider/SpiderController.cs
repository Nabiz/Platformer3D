using UnityEngine;
using UnityEngine.AI;

public class SpiderController : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private Animator spiderAnimator;
    private bool isFollowingPlayer;
    private Vector3 startingPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        spiderAnimator = GetComponentInChildren<Animator>();
        startingPosition = transform.position;

        GameObject sightRange = gameObject.transform.Find("SightRange").gameObject;
        sightRange.GetComponent<SightRange>().playerEnteredSightRange.AddListener(FollowPlayer);
        sightRange.GetComponent<SightRange>().playerLeftSightRange.AddListener(UnfollowPlayer);
        sightRange.transform.parent = null;
    }

    void Update()
    {
        if (isFollowingPlayer)
        {
            agent.destination = player.transform.position;
        }
        
        if (agent.velocity.magnitude == 0)
        {
            spiderAnimator.SetBool("Walking", false);
        }
        else
        {
            spiderAnimator.SetBool("Walking", true);
        }
    }

    private void FollowPlayer()
    {
        isFollowingPlayer = true;
    }

    private void UnfollowPlayer()
    {
        isFollowingPlayer = false;
        agent.destination = startingPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerKick"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            player.GetComponent<PlayerController>().Spawn();
            UnfollowPlayer();
        }

    }
}
