using System;
using UnityEngine;

namespace AirborneBall.PlayerInput
{
    public class PlayerInputManager : MonoBehaviour
    {
        public event Action<Vector3> OnClickPlayer = delegate { };

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                OnClickPlayer.Invoke(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            return;
#endif

            if (Input.touchCount != 0)
                OnClickPlayer.Invoke(Camera.main.ScreenToWorldPoint(Input.touches[0].position));
        }
    }
}
