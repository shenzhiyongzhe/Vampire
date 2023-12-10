using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _HP;

    LevelUp levelUp;

    int playerLv = 0;
    int _playerExp = 1;
    int levelUpExp = 30;
    public int HP
    {
        get { return _HP; }
        set { _HP = value; }
    }

    public int LvUpExp => levelUpExp;
    public int PlayerLv => playerLv;

    public static Player instance;
    private void Awake()
    {
        instance = this;
        levelUpExp = playerLv * 10 + 30;
        levelUp = GetComponent<LevelUp>();

    }

    public int PlayerExp
    {
        get { return _playerExp; }
        set 
        { 
            if(value >= levelUpExp)
            {
                _playerExp = 0;
                playerLv++;
                levelUp.OnLevelUp();

            }
            else
            {
                _playerExp = value; 
            }

        }
    }



}