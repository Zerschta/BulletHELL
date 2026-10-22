using Unity.Mathematics;
using UnityEngine;

public class Enemy_GunLogic : MonoBehaviour
{
    public Weapon Weapon;
    public Enemy_Movement Enemy;
    public Transform EnemyRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Weapon childWeapon = GetComponentInChildren<Weapon>();

        if (childWeapon != null)
        {
            Weapon = childWeapon;
        }
        else return;

            Weapon.transform.position = transform.position;
        Weapon.transform.rotation = EnemyRotation.transform.rotation * Quaternion.Euler(0,0,90);
        
        if (Enemy.FoundPlayer)
        {
            Weapon.Enemyfire();
        }
        return;
    }
}
