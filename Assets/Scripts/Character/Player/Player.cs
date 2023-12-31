﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    [SerializeField] Slider expBar;
    [SerializeField] GameObject restartWindows;

    LevelUp levelUp;

    public int NextLvExp { get; private set; } = 50;
    public int CurExp { get; private set; } = 0;
    public int PlayerLv { get; set; } = 0;
    public float PlayerLuck { get; private set; } = 0.3f;
    public float CoolDown { get; private set; } = 1f;
    public float ExpBuff { get; private set; } = 1f;

    public float FlightSpeed { get; private set; } = 1f;
    public static Player Instance { get; private set; }

    private void Awake()
    {
        Initialize();
        Instance = this;
        levelUp = GetComponent<LevelUp>();
    }

    public void GetExp(int exp)
    {
        if (exp + CurExp >= NextLvExp)
        {
            CurExp = 0;
            levelUp.OnLevelUp();
            NextLevelExp();
        }
        else
            CurExp += exp;
        expBar.value = (float)CurExp / NextLvExp;
    }

    void NextLevelExp()
    {
        NextLvExp = PlayerLv * 50 + 50;
    }

    public override IEnumerator Die()
    {
        Anim.SetBool("isDead", true);
        yield return new WaitForSeconds(1.2f);
        restartWindows.SetActive(true);
        Time.timeScale = 0f;
    }

    public override void GetHurt(int damage)
    {
        base.GetHurt(damage);
        GameObject particle = ObjectPool.GetObject("Blood");
        particle.transform.position = transform.position;
        particle.SetActive(true);
    }

    public void IncreaseLuck(float percent)
    {
        PlayerLuck *= (1 + percent);
    }

    public void IncreaseAttackPower(float percent)
    {
        AttackPower = (int)Mathf.Ceil(AttackPower * (1 + percent));
    }
    public void IncreaseDef(int def)
    {
        DefendencePower += def;
    }

    public void IncreaseMoveSpeed(float percent)
    {
        MoveSpeed *= (1 + percent);
    }

    public void IncreaseExp(float percent)
    {
        ExpBuff += percent;
    }

    public void IncreaseDamage(float percent)
    {
        DamageBuff *= (1 + percent);
    }

    public void IncreaseFlightSpeed(float percent)
    {
        FlightSpeed *= (1 + percent);
    }
    public void DecreaseCoolDownTime(float percent)
    {
        CoolDown *= (1 - percent);
    }
}