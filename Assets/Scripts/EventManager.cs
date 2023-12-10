using System;

public static class EventManager
{
    public static event Action LevelUp;

    public static void OnLevelUp()
    {
        LevelUp?.Invoke();
    }


}
