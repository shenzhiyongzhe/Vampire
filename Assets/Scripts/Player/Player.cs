using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private int _HP;
    int playerLv = 0;
    int _playerExp = 1;
    int levelUpExp = 30;

    public int LvUpExp => levelUpExp;

    //private void Awake()
    //{
    //    levelUpExp = playerLv * 10 + 30;

    //}

    //private void Update()
    //{

    //}
    public int PlayerExp
    {
        get { return _playerExp; }
        set 
        { 
            if(value >= levelUpExp)
            {
                _playerExp = 0;
                playerLv++;
                EventSys.OnLevelUp(playerLv);
            }
            else
            {
                _playerExp = value; 
            }
            EventSys.OnPickUp((float)_playerExp / levelUpExp);

        }
    }
    public int HP
    {
        get { return _HP; }
        set { _HP = value; }
    }
    


}