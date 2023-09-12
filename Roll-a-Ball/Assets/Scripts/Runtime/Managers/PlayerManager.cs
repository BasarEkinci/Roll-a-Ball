using Runtime.Controllers;
using Runtime.Data.UnityObjects;
using Runtime.Data.ValueObjects;
using Runtime.Sıgnals;
using UnityEngine;

namespace Runtime.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region Self Variables
        
        #region Serialized Variables

        [SerializeField] private PlayerMovementController playerMovementController;

        #endregion

        #region Private Variables

        private PlayerData _data;

        #endregion

        #endregion

        private void Awake()
        {
            GetPlayerData();
        }
        
        private void OnEnable()
        {
            SubscribeEvents();
        }
        
        private void Start()
        {
            SendDataToControllers();
        }
        
        private void OnDisable()
        {
            InputSignals.Instance.OnInputTaken -= playerMovementController.OnInputTaken;
        }
        
        private void GetPlayerData()
        {
            _data = Resources.Load<CD_Player>("Data/CD_Player").Data;
        }

        private void SendDataToControllers()
        {
            playerMovementController.SetMovementData(_data.MovementData);
        }
        
        private void SubscribeEvents()
        {
            InputSignals.Instance.OnInputTaken += playerMovementController.OnInputTaken;
        }

        
    }
}