using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//#if false

// source https://www.youtube.com/watch?v=mBGUY7EUxXQ

public class EnemySight : MonoBehaviour {

    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;
    public Vector3 position1 = new Vector3(1000f, 1000f, 1000f);
    public Vector3 resetPosition1 = new Vector3(1000f, 1000f, 1000f);
    public bool stay = true;

    private UnityEngine.AI.NavMeshAgent nav;
    private SphereCollider col;
    //private Animator anim;
    private LastPlayerSighting lastPlayerSighting;
    public GameObject player;
    private Animator playerAnim;
    //private PlayerHealth playerHealth;
    private HashIDs hash;
    private Vector3 previousSighting;
    public GameObject getPlayer()
    {
        return player;
    }


    void Awake()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        //anim = GetComponent<Animator>();
       // lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighing>();
       // playerAnim = player.GetComponent<Animator>();
        //playerHealth = player.GetComponent<PlayerHealth>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameManager).GetComponent<HashIDs>();

        personalLastSighting = resetPosition1;
        previousSighting = resetPosition1;
    }
    void Start()
    {
      
    }

    void Update () {
        if (position1 != previousSighting)
            personalLastSighting = position1;

        previousSighting = position1;

       // if (playerHealth.health > 0f)
            //anim.SetBool(hash.playerInSightBool, playerInSight);
        //else
        //anim.SetBool(hash.playerInSightBool, false);
        Debug.Log(playerInSight);
  

    }

    private float stayCount = 0.0f;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInSight = false;

            Vector3 direction = player.transform.position + player.transform.up;
            var self = transform.position + transform.up;
            var playertest = player.transform.position + player.transform.up - transform.position;
            float angle = Vector3.Angle(transform.forward, direction - transform.position);
            if (angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(self, playertest, out hit, 100000000))
                {
                    Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider.gameObject == player)
                    {
                        playerInSight = true;
                        position1 = player.transform.position;
                    }
                }
            }
#if false
            int playerLayerZeroStateHash = playerAnim.GetCurrentAnimatorStateInfo(0).nameHash;
            int playerLayerOneStateHash = playerAnim.GetCurrentAnimatorStateInfo(1).nameHash;

            if(playerLayerZeroStateHash == hash.locomotionState || playerLayerOneStateHash == hash.shoutState)

            {
                if(CalculatePathLenght(player.transform.position) <= col.radius)
                {
                    personalLastSighting = player.transform.position;
                }
            }
#endif
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            playerInSight = false;
    }
#if false
    float CalculatePathLenght(Vector3 targetPosition)
    {
        UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();

        if (nav.enabled)
            nav.CalculatePath(targetPosition, path);
        Vector3 allWayPoints = new Vector3[path.corners.Length + 2];

        allWayPoints[0] = transform.position;
        allWayPoints[allWayPoints.Length - 1] = targetPosition;

        for (int i = 0; i < path.corners.Length; i++)
        {
            allWayPoints[i + 1] = path.corners[i];
        }

        float pathLength = 0f;

        for (int i=0; i<allWayPoints.Length-1; i++)
        {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
        }
        return pathLength;
    }
#endif
}
//#endif
