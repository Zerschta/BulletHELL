using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData Data;
    public GameObject GunRot;
    public GameObject GunHold;
    public Transform BulletSpawner;

    private float cooldownTimer;

    private void Start()
    {
        GunRot = GameObject.Find("WeaponRotation");
        GunHold = GameObject.Find("WeaponHolder");
        BulletSpawner = transform.Find("BulletSpawner");
    }

    private void Update()
    {
        float magazine = Data.Magazine;

        if (transform.IsChildOf(GunHold.transform))
        {
            if (magazine > 0)
            {
                cooldownTimer -= Time.deltaTime;

                if (Input.GetKey(KeyCode.Space) && cooldownTimer <= 0f)
                {
                    fire();
                    cooldownTimer = Data.cooldown;
                    Debug.Log("Fire");
                    Data.Magazine -= 1;
                }
            }
            else { 
                Data.Magazine = 0;
                Debug.Log("Emptymag");
            }
            transform.position = GunHold.transform.position;
        }
    }

    public void fire()
    {
        int count = Data.count;
        float spread = Data.spread;
        float startAngle = -spread * (count - 1) / 2f;

        for (int i = 0; i < count; i++)
        {
            float angle = startAngle + spread * i;
            Quaternion rotation = GunRot.transform.rotation * Quaternion.Euler(0f, 0f, angle);

            GameObject bullet = Instantiate(Data.projectilePrefab, BulletSpawner.transform.position, rotation);
            bullet.GetComponent<BulletMovement>().Speed = Data;
        }

        if (Data.shootSound != null)
        {
            AudioSource.PlayClipAtPoint(Data.shootSound, BulletSpawner.transform.position);
        }
    }
}
