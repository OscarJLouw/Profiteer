using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Weapon : MonoBehaviour
{
    protected const int MAXLEVEL = 10;
    public enum WeaponStat
    {
        Firepower = 0,
        Range = 1,
        Movement = 2,
    }
    Weapon(int[] givenAbility)
    {
        m_strength = givenAbility;
        cost = givenAbility[0] + givenAbility[1] + givenAbility[2];
    }
    int[] m_strength;
    public int GetStatLength() { return m_strength.Length; }
    int cost;
    public int GetStrength(WeaponStat givenWeaponType) { return m_strength[(int) givenWeaponType]; }
    public int GetStrength(int givenWeaponNumber) { return GetStrength(ConvertIntToWeaponType(givenWeaponNumber)); }
    public WeaponStat ConvertIntToWeaponType(int givenInt)
    {
        switch(givenInt)
        {
            case 1: return WeaponStat.Firepower;
            case 2: return WeaponStat.Movement;
            case 3: return WeaponStat.Range;
            default: throw new Exception("Unused weaponType of " + givenInt + " was given");
        }
    }
    public static Weapon Fight(Weapon firstWeapon, Weapon secondWeapon)
    {
        int score = 0;
        for(int i = 0; i < firstWeapon.GetStatLength(); i++)
        {
            for(int j = 0; j < secondWeapon.GetStatLength(); j++)
            {
                if (StrengthModifier(i, j) * firstWeapon.GetStrength(i) > secondWeapon.GetStrength(j))
                {
                    score++;
                }
                else if (StrengthModifier(i, j) * firstWeapon.GetStrength(i) < secondWeapon.GetStrength(j))
                {
                    score--;
                }
            }
        }
        if(score > 0)
        {
            return firstWeapon;
        }
        else if (score < 0)
        {
            return secondWeapon;
        }
        return null;
    }

    public static float StrengthModifier(int attackingWeapontype,int defendingWeaponType)
    {
        switch(attackingWeapontype)
        {
            case 0:
                    switch(defendingWeaponType)
                    {
                        case 0: return 1;
                        case 1: return 0.8f;
                        case 2: return 1.5f;
                        default: throw new Exception("Unused weaponType of "+defendingWeaponType+" was given");
                    }
            case 1:
                    switch (defendingWeaponType)
                {
                    case 0: return 1.5f;
                    case 1: return 1;
                    case 2: return 0.8f;
                    default: throw new Exception("Unused weaponType of " + defendingWeaponType + " was given");
                }
            case 2:
                switch (defendingWeaponType)
                {
                    case 0: return 0.8f;
                    case 1: return 1.5f;
                    case 2: return 1;
                    default: throw new Exception("Unused weaponType of " + defendingWeaponType + " was given");
                }
            default: throw new Exception("Unused weaponType of " + attackingWeapontype + " was given");

        }

    }
}
