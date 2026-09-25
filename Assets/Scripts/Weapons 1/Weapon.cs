using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData Data;
    public GameObject GunRot;
    public GameObject BulletSpawner;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fire();
        }
    }
    public void fire()
    {
        Instantiate(Data.projectilePrefab);
        Data.projectilePrefab.transform.position = BulletSpawner.transform.position;
        Data.projectilePrefab.transform.rotation = GunRot.transform.rotation;
    }
    
}
