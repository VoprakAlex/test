using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class HealthSystemTests
{
    [TestMethod]
    public void SetToMax_ShouldSetCurrentHealthToMaxAndNotDead()
    {
        // Arrange
        var health = new HealthSystem();
        health.MaxHealth = 100;
        health.CurrentHealth = 50;
        health.IsDead = true;

        // Act
        health.SetToMax();

        // Assert
        Assert.AreEqual(100, health.CurrentHealth);
        Assert.IsFalse(health.IsDead);
    }

    [TestMethod]
    public void DecreaseHP_WhenAliveAndAmountPositive_ShouldDecreaseHealth()
    {
        // Arrange
        var health = new HealthSystem();
        health.MaxHealth = 100;
        health.CurrentHealth = 80;
        health.IsDead = false;

        // Act
        health.DecreaseHP(30);

        // Assert
        Assert.AreEqual(50, health.CurrentHealth);
        Assert.IsFalse(health.IsDead);
    }

    [TestMethod]
    public void DecreaseHP_WhenHealthBecomesZero_ShouldDie()
    {
        // Arrange
        var health = new HealthSystem();
        health.MaxHealth = 100;
        health.CurrentHealth = 30;
        health.IsDead = false;

        // Act
        health.DecreaseHP(30);

        // Assert
        Assert.AreEqual(0, health.CurrentHealth);
        Assert.IsTrue(health.IsDead);
    }

    [TestMethod]
    public void DecreaseHP_WhenHealthGoesBelowZero_ShouldDieAndSetHealthToZero()
    {
        // Arrange
        var health = new HealthSystem();
        health.MaxHealth = 100;
        health.CurrentHealth = 20;
        health.IsDead = false;

        // Act
        health.DecreaseHP(50);

        // Assert
        Assert.AreEqual(0, health.CurrentHealth);
        Assert.IsTrue(health.IsDead);
    }

    [TestMethod]
    public void DecreaseHP_WhenDead_ShouldNotChangeHealth()
    {
        // Arrange
        var health = new HealthSystem();
        health.MaxHealth = 100;
        health.CurrentHealth = 50;
        health.IsDead = true;

        // Act
        health.DecreaseHP(10);

        // Assert
        Assert.AreEqual(50, health.CurrentHealth);
        Assert.IsTrue(health.IsDead);
    }

    [TestMethod]
    public void DecreaseHP_WithNegativeAmount_ShouldNotChangeHealth()
    {
        // Arrange
        var health = new HealthSystem();
        health.MaxHealth = 100;
        health.CurrentHealth = 50;
        health.IsDead = false;

        // Act
        health.DecreaseHP(-5);

        // Assert
        Assert.AreEqual(50, health.CurrentHealth);
        Assert.IsFalse(health.IsDead);
    }

    [TestMethod]
    public void IncreaseHP_WhenAliveAndAmountPositive_ShouldIncreaseHealth()
    {
        // Arrange
        var health = new HealthSystem();
        health.MaxHealth = 100;
        health.CurrentHealth = 30;
        health.IsDead = false;

        // Act
        health.IncreaseHP(20);

        // Assert
        Assert.AreEqual(50, health.CurrentHealth);
        Assert.IsFalse(health.IsDead);
    }

    [TestMethod]
    public void IncreaseHP_WhenExceedsMax_ShouldCapAtMax()
    {
        // Arrange
        var health = new HealthSystem();
        health.MaxHealth = 100;
        health.CurrentHealth = 90;
        health.IsDead = false;

        // Act
        health.IncreaseHP(20);

        // Assert
        Assert.AreEqual(100, health.CurrentHealth);
        Assert.IsFalse(health.IsDead);
    }

    [TestMethod]
    public void IncreaseHP_WhenDead_ShouldNotChangeHealth()
    {
        // Arrange
        var health = new HealthSystem();
        health.MaxHealth = 100;
        health.CurrentHealth = 50;
        health.IsDead = true;

        // Act
        health.IncreaseHP(10);

        // Assert
        Assert.AreEqual(50, health.CurrentHealth);
        Assert.IsTrue(health.IsDead);
    }

    [TestMethod]
    public void IncreaseHP_WithNegativeAmount_ShouldNotChangeHealth()
    {
        // Arrange
        var health = new HealthSystem();
        health.MaxHealth = 100;
        health.CurrentHealth = 50;
        health.IsDead = false;

        // Act
        health.IncreaseHP(-5);

        // Assert
        Assert.AreEqual(50, health.CurrentHealth);
        Assert.IsFalse(health.IsDead);
    }

    [TestMethod]
    public void Revive_WithPositiveAmount_ShouldSetHealthAndAlive()
    {
        // Arrange
        var health = new HealthSystem();
        health.MaxHealth = 100;
        health.CurrentHealth = 0;
        health.IsDead = true;

        // Act
        health.Revive(70);

        // Assert
        Assert.AreEqual(70, health.CurrentHealth);
        Assert.IsFalse(health.IsDead);
    }

    [TestMethod]
    public void Revive_WithAmountExceedingMax_ShouldCapAtMax()
    {
        // Arrange
        var health = new HealthSystem();
        health.MaxHealth = 100;
        health.CurrentHealth = 0;
        health.IsDead = true;

        // Act
        health.Revive(150);

        // Assert
        Assert.AreEqual(100, health.CurrentHealth);
        Assert.IsFalse(health.IsDead);
    }

    [TestMethod]
    public void Revive_WithZeroOrNegativeAmount_ShouldDoNothing()
    {
        // Arrange
        var health = new HealthSystem();
        health.MaxHealth = 100;
        health.CurrentHealth = 0;
        health.IsDead = true;

        // Act
        health.Revive(0);
        // Assert
        Assert.AreEqual(0, health.CurrentHealth);
        Assert.IsTrue(health.IsDead);

        // Act again with negative
        health.Revive(-10);
        // Assert
        Assert.AreEqual(0, health.CurrentHealth);
        Assert.IsTrue(health.IsDead);
    }

    [TestMethod]
    public void Die_ShouldSetDeadAndHealthToZero()
    {
        // Arrange
        var health = new HealthSystem();
        health.MaxHealth = 100;
        health.CurrentHealth = 75;
        health.IsDead = false;

        // Act
        health.Die();

        // Assert
        Assert.AreEqual(0, health.CurrentHealth);
        Assert.IsTrue(health.IsDead);
    }

    [TestMethod]
    public void Die_WhenAlreadyDead_ShouldRemainDeadAndHealthZero()
    {
        // Arrange
        var health = new HealthSystem();
        health.MaxHealth = 100;
        health.CurrentHealth = 0;
        health.IsDead = true;

        // Act
        health.Die();

        // Assert
        Assert.AreEqual(0, health.CurrentHealth);
        Assert.IsTrue(health.IsDead);
    }
}