using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed = 2f;
    public float minTime = 1f;   
    public float maxTime = 3f;   
    public float cooldown = 0.3f;

    private float timer = 0f;
    private float closedcooldown;

    void Start()
    {
        closedcooldown = cooldown;
        NewDirection();
    }

    void Update()
    {

        timer -= Time.deltaTime;
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
    }
}
