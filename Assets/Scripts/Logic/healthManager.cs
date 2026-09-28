using UnityEngine;
using UnityEngine.UI;

public class healthManager : MonoBehaviour
{
    public Image HealthBar;
    public float HealthAmount = 100f;
    private float MaxHealth;
    public float yOffset;
    void Start()
    {
        MaxHealth = HealthAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == null) return;

        transform.position = transform.parent.position + new Vector3(0f, yOffset, 0f);
        transform.rotation = Quaternion.identity;

        death();
    }

    public void TakeDamage(float damage)
    { 
        HealthAmount -= damage;
        HealthBar.fillAmount = HealthAmount / MaxHealth;
    }

    public void Heal(float HealingAmount)
    { 
        HealthAmount += HealingAmount;
        HealthAmount = Mathf.Clamp(HealthAmount, 0, MaxHealth);

        HealthBar.fillAmount = HealingAmount / MaxHealth;
    }

    void death()
    {
        if (HealthAmount <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
