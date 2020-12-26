/// <summary>
/// Allows you to use this Enum to compare actions together without having to hard code anything.
/// comparison example EAnimationStates.moving == EAnimationStates.moving or convert it to String (EAnimationStates.moving.ToString()
/// </summary>
[System.Serializable]
public enum EAnimationStates
{
    moving, // Means walking, running, etc.
    hit,
    idle,
    cheering,
    throwObject,
    reloading,
    death
}
