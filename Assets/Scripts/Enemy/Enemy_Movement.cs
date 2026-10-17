using System.Text;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
public class Enemy_Movement : MonoBehaviour
{
    public float speed = 2f;
    public float minTime = 1f;   
    public float maxTime = 3f;   
   
    public float minCooldown = 0.3f;
    public float maxCooldown = 2f;
    public float cooldown;

    private float timer = 0f;
    private float closedcooldown;

    float range = 5f;

    [SerializeField] LayerMask layerMask;
    [SerializeField] CircleCollider2D FOV;
    [SerializeField] GameObject player;
    

    void Start()
    {   
        NewDirection();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " ist im FOV breicht von : " + transform.name);
    }

    void Update()
    {

        timer -= Time.deltaTime;

        RayCast();
        if (timer <= 0f)
        {
            closedcooldown -= Time.deltaTime;
            if (closedcooldown <= 0f) {
                NewDirection();
                closedcooldown = cooldown;
            }
        }
        else if (timer > 0f)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }

    void NewDirection()
    {
        float angle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        timer = Random.Range(minTime, maxTime);
        cooldown = Random.Range(minCooldown, maxCooldown);
    }

    void RayCast()
    {
        Vector2 start = transform.position;
        Vector2 position = transform.up; 
        
        RaycastHit2D hit = Physics2D.Raycast(start, position, range, layerMask);

        if (hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            closedcooldown -= Time.deltaTime;
            if (closedcooldown <= 0f)
            {
                NewDirection();
                Debug.Log( transform.name +  " :  RAYCAST wall collision");
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.up * range);
    }
}
