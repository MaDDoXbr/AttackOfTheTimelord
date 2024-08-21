using System.Collections;
using UnityEngine;

public class Armor : MonoBehaviour, IArmor
{
    public int health;
    [SerializeField]
    private int maxHealth = 20;
    void Awake()
    {
        health = maxHealth;
    }
    //
    // void Update()
    // {
    //     
    // }

    public IEnumerable ApplyDamage(int Damage)
    {
        health = health - Damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        yield return null;
    }
    

    public IEnumerable DecreaseArmor(float Percentage)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable IncreaseArmor(float Percentage)
    {
        throw new System.NotImplementedException();
    }

    public int? GetHealth()
    {
        throw new System.NotImplementedException();
    }

    public bool? IsDestructible()
    {
        throw new System.NotImplementedException();
    }

    public bool IsDestructibleNonNullable()
    {
        throw new System.NotImplementedException();
    }
}
