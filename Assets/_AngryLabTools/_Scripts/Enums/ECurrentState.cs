/// <summary>
/// Allows you to use this Enum to compare actions together without having to hard code anything.
/// comparison example ECurrentState.moving == ECurrentState.moving or convert it to String (ECurrentState.moving.ToString()
/// </summary>
[System.Serializable]
internal enum ECurrentState
{
    moving, // Means walking, running, etc.
    hit,
    idle,
    cheering,
    throwObject,
    reloading,
    death
}