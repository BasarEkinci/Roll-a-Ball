using Runtime.Keys;
using Runtime.Sıgnals;
using Unity.Mathematics;
using UnityEngine;

namespace Runtime.Managers
{
    public class InputManager : MonoBehaviour
    {
        #region Self Variables

        #region Private Variables

        private float2 _inputVales;

        #endregion

        #endregion
        
        private void Update()
        {
            _inputVales = GetInputValues();
            if(!Input.anyKey) return;   
            OnSendInput();
        }

        private void OnSendInput()
        {
            InputSignals.Instance.OnInputTaken?.Invoke(new InputParams()
            {
                InputValues = _inputVales
            });
        }

        private float2 GetInputValues()
        {
            return new float2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        
    }
}