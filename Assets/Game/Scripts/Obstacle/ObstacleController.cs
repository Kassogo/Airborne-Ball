using System;
using UnityEngine;

namespace AirborneBall.Obstacle
{
    public class ObstacleController : MonoBehaviour
    {
        public event Action<ObstacleController> OnNotNeedObject; 

        protected void OnBecameInvisible()
        {
            OnNotNeedObject?.Invoke(this);
        }

    }
}
