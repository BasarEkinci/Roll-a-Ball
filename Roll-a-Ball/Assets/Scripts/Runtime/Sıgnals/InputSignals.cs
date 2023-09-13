﻿using Runtime.Keys;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Sıgnals
{
    public class InputSignals : MonoBehaviour
    {
        #region Singelton

        public static InputSignals Instance;

        private void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        #endregion
        
        public UnityAction<InputParams> OnInputTaken = delegate {  };
    }
}