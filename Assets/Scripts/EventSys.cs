using System;

public static class EventSys
{
    public static event Action<float> PickCrystal;
    //public static event Action LevelUp;

    public static void OnPickUp(float percent)
    {
        PickCrystal?.Invoke(percent);
    }
    //public static void PlayerLvUp()
    //{
    //    LevelUp?.Invoke();
    //}
}
