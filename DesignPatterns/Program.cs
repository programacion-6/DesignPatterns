namespace DesignPatterns;

/// <summary>
/// Partes:
///     1. Abstracta o la super clase
///     2. Subclases o clases concretas
/// </summary>
/// 

//public class Warrior
//{
//    public void PrepareForBattle()
//    {
//        Console.WriteLine("Armor equipped.");
//        Console.WriteLine("Sword equipped.");
//        Console.WriteLine("Warrior uses Berserk mode.");
//        Console.WriteLine("Character is ready for battle?");
//    }
//}

//public class Mage
//{
//    public void PrepareForBattle()
//    {
//        Console.WriteLine("Armor equipped.");
//        Console.WriteLine("Staff equipped.");
//        Console.WriteLine("Mage casts Shield spell.");
//        Console.WriteLine("Character is ready for battle?");
//    }
//}

// TEMPLATE METHOD
// Si se nota una serie de pasos y codigo repetido acoplado a estos
// entonces puedo pensar en implementar el template method design pattern
public abstract class Character
{
    /// <summary>
    /// Una serie de pasos
    /// </summary>
    public void PrepareForBattle()
    {
        EquipArmor();
        EquipoWeapon();
        if (HasSpecialSkill())
        {
            UseSpecialSkill();
        }
        ReadyForBattle();
    }

    protected void EquipArmor()
    {
        Console.WriteLine("Armor equiped.");
    }

    protected abstract void EquipoWeapon();

    protected virtual bool HasSpecialSkill() => false;

    protected virtual void UseSpecialSkill()
    {
        // Default implementation (can be overridden by subclasses)
    }

    protected void ReadyForBattle()
    {
        Console.WriteLine("Character is ready for battle!");
    }
}

public class Warrior : Character
{
    protected override void EquipoWeapon()
    {
        Console.WriteLine("Sword equipped.");
    }

    protected override bool HasSpecialSkill()
    {
        return true;
    }

    protected override void UseSpecialSkill()
    {
        Console.WriteLine("Warrior uses Berserker mode.");
    }
}

public class Mage : Character
{
    protected override void EquipoWeapon()
    {
        Console.WriteLine("Staff equipped.");
    }

    protected override bool HasSpecialSkill()
    {
        return true;
    }

    protected override void UseSpecialSkill()
    {
        Console.WriteLine("Mage casts Shield spell.");
    }
}

public class Program
{
    static void Main()
    {
        var warrior = new Warrior();
        warrior.PrepareForBattle();

        Console.WriteLine();

        var mage = new Mage();
        mage.PrepareForBattle();
    }
}
