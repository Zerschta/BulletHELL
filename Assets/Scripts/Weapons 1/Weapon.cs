using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData Data;
    public GameObject GunRot;
    public GameObject GunHold;
    public GameObject BulletSpawner;

    private void Start()
    {
        GunRot = GameObject.Find("WeaponRotation");
        GunHold = GameObject.Find("WeaponHolder");
    }
    private void Update()
    {
        if (transform.IsChildOf(GunHold.transform))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fire();
            }
            transform.position = GunHold.transform.position;
        }
    }
    public void fire()
    {
        
        GameObject bullet = Instantiate(Data.projectilePrefab, BulletSpawner.transform.position , GunRot.transform.rotation);
         
    }
    
}
