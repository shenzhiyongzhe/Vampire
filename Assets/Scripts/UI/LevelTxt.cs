using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class LevelTxt : MonoBehaviour
{
    private TMP_Text _textMeshPro;

    private void OnEnable()
    {
        EventSys.LevelUp += ModifyTxt;
    }
    private void OnDisable()
    {
        EventSys.LevelUp -= ModifyTxt;
    }
    // Use this for initialization
    void Awake()
    {
        _textMeshPro = GetComponent<TMP_Text>();
    }

    void ModifyTxt(int level)
    {
        _textMeshPro.text = $"等级：{level}";
    }
}
