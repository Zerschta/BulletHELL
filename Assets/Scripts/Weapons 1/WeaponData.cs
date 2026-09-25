using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int damage;
    public int spread;
    public int count;
    public int cooldown;
    public int fireRate;
    public int Range;
    public AudioClip shootSound;
    public GameObject projectilePrefab;
}
