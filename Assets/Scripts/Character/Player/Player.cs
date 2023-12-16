using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _HP;
    [SerializeField] Slider expBar;
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
    public int PlayerLv { get; set; } = 0;

    public static Player Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
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
                levelUp.OnLevelUp();
            }
            else
            {
                _playerExp = value; 
            }
            expBar.value = (float)PlayerExp / LvUpExp;
        }
    }



}