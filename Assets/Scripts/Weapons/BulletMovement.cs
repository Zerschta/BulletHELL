using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public WeaponData Speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    { 
        transform.position += transform.right * Time.deltaTime * Speed.bulletSpeed;
    }
}
