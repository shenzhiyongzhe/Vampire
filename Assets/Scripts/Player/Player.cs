using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _HP;
    int playerLevel = 0;
    int playerExp = 0;

    public int PlayerExp
    {
        get { return playerExp; }
        set { playerExp = value; }
    }
    public int HP
    {
        get { return _HP; }
        set { _HP = value; }
    }
    // Use this for initialization

}