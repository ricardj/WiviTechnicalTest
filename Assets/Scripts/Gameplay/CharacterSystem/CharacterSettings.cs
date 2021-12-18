using System;

[Serializable]
public class CharacterSettings
{
    public float speed = 3f;
    public float dashSpeed = 3f;
    public float dashDuration = 0.3f;

    internal float GetSpeed()
    {
        return speed;
    }

    internal float GetDashSpeed()
    {
        return dashSpeed;
    }
    public float GetDashDuration()
    {
        return dashDuration;
    }
}
