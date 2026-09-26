using NUnit.Framework.Constraints;
using Unity.Mathematics;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public GameObject Gun;
    public GameObject WeaponHolder;
    public GameObject WeaponRotation;

    public GameObject CurrentGun;
    public bool pickup;

    private void Start()
    {
        WeaponHolder = GameObject.Find("WeaponHolder");
        WeaponRotation = GameObject.Find("WeaponRotation");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && WeaponHolder.transform.childCount == 1)
        {
            CurrentGun = WeaponHolder.transform.GetChild(0).gameObject;

            CurrentGun.transform.SetParent(null);
            CurrentGun.transform.position = WeaponHolder.transform.position;
            CurrentGun.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Gun == null)
            return;
        if (Input.GetKeyDown(KeyCode.E) && pickup && WeaponHolder.transform.childCount == 0)
        {
            Gun.gameObject.transform.SetParent(WeaponHolder.transform);
            Gun.transform.rotation = WeaponRotation.transform.rotation;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Weapon"))
        {
            pickup = true;
            Gun = collision.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        pickup = false;
        Gun = null;
    }
}
