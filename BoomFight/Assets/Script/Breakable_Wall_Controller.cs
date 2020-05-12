using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Breakable_Wall_Controller : MonoBehaviour
{
    [SerializeField]
    int Wall_Health = 1;

    [SerializeField]
    public List<GameObject> Power_Ups; //Här lägger man alla power_ups som har ett chans att spawna

    [SerializeField]
    int[] lootTable =
    {
        40, //power-up A

        40, //power-up B

        20 //Power-up C
    }; //Detta är möjligheterna av hur stor chanser är att en spawnar

    [SerializeField]
    int total;

    [SerializeField]
    int randomNumber;

    bool WallDestroyed = false;

    private void Start()
    {
        foreach (var item in lootTable)
        {
            total += item;
        }

        randomNumber = UnityEngine.Random.Range(0, total);

        if (WallDestroyed = true) //när vägen blir förstörd kommer ett power-up att spawna från listan
        {
            for (int i = 0; i < lootTable.Length; i++)
            {
                if (randomNumber <= lootTable[i])
                {
                    Power_Ups[i].SetActive(true);
                    Instantiate(Power_Ups[i], transform.position, Quaternion.identity);
                    return;
                }
                else
                {
                    randomNumber -= lootTable[i];
                }
            }
        }

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Wall_Health <= 0) //Vägen har bara ett health
        {
            WallDestroyed = true;

            Destroy(this);
        }
    }
}
