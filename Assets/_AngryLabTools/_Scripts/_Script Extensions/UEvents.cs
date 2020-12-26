using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine;
namespace AngryLab
{
    public sealed partial class UEvents
    {
        [System.Serializable]
        public class EString : UnityEvent<string> { }

        [System.Serializable]
        public class EScene : UnityEvent<Scene> { }

        [System.Serializable]
        public class EBool : UnityEvent<bool> { }

        [System.Serializable]
        public class EInt : UnityEvent<int> { }

        [System.Serializable]
        public class EFloat : UnityEvent<float> { }

        [System.Serializable]
        public class EVector2 : UnityEvent<Vector2> { }

        [System.Serializable]
        public class EVector3 : UnityEvent<Vector3> { }

        [System.Serializable]
        public class EQuaternion : UnityEvent<Quaternion> { }

        [System.Serializable]
        public class EFloatDouble : UnityEvent<float, float> { }

        [System.Serializable]
        public class EObject : UnityEvent<object> { }

        [System.Serializable]
        public class EGObject : UnityEvent<GameObject> { }

        // Game Specific --- Remove for new projects

        [System.Serializable]
        public class EItem : UnityEvent<Ab_BaseItemInfo> { }

    }
}