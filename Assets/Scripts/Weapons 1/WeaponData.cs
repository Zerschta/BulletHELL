using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData",
    menuName = "Scriptable Objects/WeaponData")]

public class WeaponData : ScriptableObject
{
    public string weaponName;

    public int damage;
    public int spread;
    public int count;

    public float cooldown;
    public float bulletSpeed;
    public float fireRate;
    public float range;

    public AudioClip shootSound;
    public GameObject projectilePrefab;
}