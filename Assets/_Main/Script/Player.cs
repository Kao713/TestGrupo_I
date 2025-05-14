using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
            health = 0;
        if (damage < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(damage), "Damage cannot be negative.");
            }
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > 100)
            health = 100;
    }
}
