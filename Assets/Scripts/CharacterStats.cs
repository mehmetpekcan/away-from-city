using UnityEngine;

public class CharacterStats : MonoBehaviour {
    public int maxHealth = 100;
    public bool isDead;
    public HealthBar healthBar;
    public int currentHealth {
        get;
        private set;
    }

    public Stat damage;
    public Stat armor;   

    void Awake() {
        currentHealth = maxHealth;
    }

    void Start() {
        isDead = false;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.T)){
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage){
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0 && !isDead) {
            isDead = true;
            Die();
        } else if (currentHealth > 0) {
            Debug.Log(transform.name + " takes " + damage + " damage!");
        }
    }


    public virtual void Die() {
        Debug.Log(transform.name + " died!");
    }
}
