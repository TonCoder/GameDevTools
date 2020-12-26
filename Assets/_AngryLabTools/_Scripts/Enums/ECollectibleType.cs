/// <summary>
/// Allows you to use this Enum to compare actions together without having to hard code anything.
/// comparison example ECollectibleType.IsMoney == ECollectibleType.IsMoney or convert it to String (ECollectibleType.IsMoney.ToString()
/// </summary>
[System.Serializable]
public enum ECollectibleType
{
    IsMoney,
    IsHealth,
    IsAmmo,
    IsSpecialCurrency
}