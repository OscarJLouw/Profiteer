using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contract : MonoBehaviour
{

    int m_expiryDate;
    int m_payment;
    Weapon m_weapon;

	public Contract(int givenPayment)
    {
        m_payment = givenPayment;
    }

    public void ChooseWeapon(Weapon[] givenWeapon, int[] givenPreferanceRating)
    {
        int bestValue = -1;
        for(int i = 0; i < givenWeapon.Length; i++)
        {
            int tempBestValue = 0;
            for(int j = 0; j < givenWeapon[i].GetStatLength(); j++)
            {
                tempBestValue += givenWeapon[i].GetStrength(j) * givenPreferanceRating[j]; 
            }
            if(bestValue < tempBestValue)
            {
                bestValue = tempBestValue;
                m_weapon = givenWeapon[i];
            }
        }
    }
}

