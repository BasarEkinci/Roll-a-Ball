using System;
using Runtime.Data.ValueObjects;
using Runtime.Keys;
using Runtime.Managers;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] private PlayerManager manager;
        
        #endregion

        #region Private Variables
        
        private float2 _inputVales;
        private Rigidbody _playerRb;
        private PlayerMovementData _data;
        
        #endregion

        #endregion

        private void Awake()
        {
            GetReferences();
        }
        internal void OnInputTaken(InputParams inputParams)
        {
            _inputVales = inputParams.InputValues;
        }
        private void FixedUpdate()
        {
            MovePlayer();
        }
        private void GetReferences()
        {
            _playerRb = GetComponent<Rigidbody>();
        }
        private void MovePlayer()
        {
            _playerRb.velocity += new Vector3(_inputVales.x, 0, _inputVales.y) * (_data.Speed * Time.fixedDeltaTime);
        }

        internal void SetMovementData(PlayerMovementData movementData)
        {
            _data = movementData;
        }
    }
}