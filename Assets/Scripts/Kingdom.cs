using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kingdom : MonoBehaviour
{
    List<Contract> m_contract;
    string m_name;
    int[] relation;
    int[] m_preference;
    int m_income;
    int m_bank;

    public Kingdom(int[] givenPreferanceRating)
    {
        m_contract = new List<Contract>();
        m_preference = givenPreferanceRating;
    }

    public void CreateContract()
    {
        Contract newContract = new Contract(m_bank);

    }
}
