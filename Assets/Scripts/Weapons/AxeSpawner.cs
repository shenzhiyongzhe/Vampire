﻿using System.Collections;
using UnityEngine;


public class AxeSpawner : WeaponSpawner
{

    protected override IEnumerator StartAttack()
    {
        Debug.Log("Axe Spawned。。。");
        yield return null;
    }

}