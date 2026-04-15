// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


public class HealthSystem
{
    public int MaxHealth;
    public int CurrentHealth;
    public bool IsDead;

    public void SetToMax()
    {
        CurrentHealth = MaxHealth;
        IsDead = false;
    }
    public void DecreaseHP(int amount)
    {
        if (IsDead) return;
        if (amount < 0) return;
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
    public void IncreaseHP(int amount)
    {
        if (IsDead) return;
        if (amount < 0) return;
        CurrentHealth += amount;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }
    public void Revive(int amount)
    {
        if (amount <= 0) return;
        IsDead = false;
        CurrentHealth = amount;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }
    public void Die()
    {
        IsDead = true;
        CurrentHealth = 0;
    }
}