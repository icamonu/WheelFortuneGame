using System;
using UnityEngine;

namespace WheelFortune.State
{
    public abstract class StateListenerBase<T,K> : MonoBehaviour where T : StateControllerBase<K> where K: Enum
    {
        [SerializeField] protected T controller;
        
        protected virtual void Awake()
        {
            controller.OnStateChanged += OnStateChanged;
        }

        protected void OnDisable()
        {
            controller.OnStateChanged -= OnStateChanged;
        }

        protected abstract void OnStateChanged(K newState, K oldState);
    }
}