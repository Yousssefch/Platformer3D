using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent navMesh;
    public Rigidbody rb;
    public float speedWalk;
    public float speedRun;
    public LayerMask whatisplayer,whatisenemy,ground;
    public float timeAttack;
    bool Attacked;
    public float sightrange,attackrange;
    public bool playerInSightRange,playerInAttackRange;
    public Rigidbody projectile;
    Rigidbody thisrb;
    public float enemyHeight;

    public Transform player;
    public void Awake(){
        player = GameObject.Find("Player").transform;
        navMesh = GetComponent<NavMeshAgent>();
        thisrb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position,sightrange,whatisplayer);
        playerInAttackRange = Physics.CheckSphere(transform.position,attackrange,whatisplayer);


        if(playerInAttackRange && playerInSightRange) Attack();
        transform.LookAt(player);
        
    }


    void OnCollisionEnter(Collision col){
        if (col.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("dead");
        }
    }
    
    
    private void ChasePlayer(){
        if (!Attacked)
        {
          navMesh.SetDestination(player.position);  
        }
        

    }
    private void Attack(){
        

        if (!Attacked)
        {
            Vector3 attackingPos = new Vector3(transform.position.x,transform.position.y+enemyHeight,transform.position.z);
            Rigidbody rb = Instantiate(projectile,attackingPos,Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward*32f,ForceMode.Impulse);
            Attacked = true;
            Invoke(nameof(ResetAttack),timeAttack);
        }

    }
    private void ResetAttack(){
        Attacked = false;

    }
    
    
}
