using System;
using UnityEngine;

namespace WheelFortune.State
{
    public abstract class StateControllerBase<T> : MonoBehaviour where T : Enum
    {
        public T CurrentState { get; private set; }
        public Action<T,T> OnStateChanged;

        public virtual void SetState(T newState)
        {
            if(newState.Equals(CurrentState)) return;
            
            T oldState = CurrentState;
            CurrentState = newState;
            OnStateChanged?.Invoke(CurrentState, oldState);
        }
    }
}