using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class EnemyController : MonoBehaviour
{
    [Header("Stats")]
    public int curHP;
    public int maxHP;
    public int scoreToGive;

    [Header("Movement")]
    public float moveSpeed;
    public float attackRange;

    public float yPathOffset;

    private List<Vector3> path;
    
    private WeaponController weapon;
    private GameObject target;

    private bool isGlowing = false;
    private MeshRenderer meshy;
    public GameObject Eye;

    private Rigidbody rigby;



    void Awake()
    {
        weapon = GetComponent<WeaponController>();
        target = FindObjectOfType<PlayerController>().gameObject;
        meshy = Eye.GetComponent<MeshRenderer>();

        rigby = GetComponent<Rigidbody>();


        UpdatePath();
    }
    // Start is called before the first frame update
    void Start()
    {
        // Gather the Components
        
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
    }

    void UpdatePath()
    {
        // Calculate a path to the target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        // Save path as a list
        path = navMeshPath.corners.ToList();
    }

    void ChaseTarget()
    {
        if(path.Count == 0)
            return;

        // Move towards the closest path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);
        

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }

    
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        
        if(curHP <= 0)
            Ded();
    }
    
    
    void Ded()
    {
        //rigby.constraints = Rigidbody.contraints.None;
        rigby.AddForce(Vector3.back * 10, ForceMode.Impulse);
        rigby.AddForce(Vector3.up * 5, ForceMode.Impulse);
        
        GameManager.instance.AddScore(scoreToGive);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //Look at target
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

        transform.eulerAngles = Vector3.up * angle;

        // Look at the target
        transform.LookAt(target.transform);
        
        //Get distance from enemy to player
        float dist = Vector3.Distance(transform.position, target.transform.position);
        
        if(dist <= attackRange)
        {
                
            if(!isGlowing)
            {
                meshy.material.EnableKeyword("_EMISSION");
                isGlowing = true;
            }
            if(weapon.CanShoot())
            {
                weapon.Shoot();
            }
        }

        else
        {
            ChaseTarget();
            
            if(isGlowing)
            {
                meshy.material.DisableKeyword("_EMISSION");
                isGlowing = false;
            }
        }
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if(other.gameObject.CompareTag("Projectile"))
    //         TakeDamage(1);
    //         //other.setActive(false);
    // }

}
