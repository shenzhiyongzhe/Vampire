using System.Collections;
using UnityEngine;

public class Accessory : MonoBehaviour
{


    public static void IncreaseAttribute(AccessoryData.AccessoryType type)
    {
        switch (type)
        {
            case AccessoryData.AccessoryType.Armor: Player.Instance.IncreaseDef(1); break;
            case AccessoryData.AccessoryType.Clover:Player.Instance.IncreaseLuck(0.2f); break;
            case AccessoryData.AccessoryType.Crown: Player.Instance.IncreaseExp(0.3f); break;
            case AccessoryData.AccessoryType.EmptyTome: Player.Instance.DecreaseCoolDownTime(0.1f); break;
            case AccessoryData.AccessoryType.Spinach:Player.Instance.IncreaseDamage(0.1f); break;    
            case AccessoryData.AccessoryType.Wings: Player.Instance.IncreaseMoveSpeed(0.1f); break;
            case AccessoryData.AccessoryType.FlightSpeed: Player.Instance.IncreaseFlightSpeed(0.3f); break;
        }
    }

}
