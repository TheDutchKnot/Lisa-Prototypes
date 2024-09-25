using UnityEngine;

[CreateAssetMenu(menuName = "ObjectPooling/PoolObjectSettings/Default", fileName = "DefaultPoolObjectSettings")]
public class DefaultPoolObjectSettings : PoolObjectSettings {
    [field: Header("Despawn"), Tooltip("At 0 object doesnt despawn after delay"), SerializeField]
    public float AfterDelay { get; private set; } = 0f;
}
