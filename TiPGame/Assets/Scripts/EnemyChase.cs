using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyChase : MonoBehaviour
{
    public InteractWithObjects objectInteraction;
    [SerializeField] float moveSpeed = 5f;

    NavMeshAgent agent;
    Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if(objectInteraction.hasPlayedAudio){
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            target = player.transform;
        }

        agent.speed = moveSpeed;
        if (target)
        {
            agent.SetDestination(target.position);
        }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
