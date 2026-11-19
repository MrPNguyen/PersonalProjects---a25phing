using System;
using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class PlayerCamSetup : MonoBehaviour
{
    [SerializeField] private CinemachineCamera playerCam;
    [SerializeField] private CinemachineBrain brain;
    
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        if (_playerInput.playerIndex == 0)
        {
            playerCam.OutputChannel = OutputChannels.Channel01;
            brain.ChannelMask = OutputChannels.Channel01;
        }
        else if (_playerInput.playerIndex == 1)
        {
            playerCam.OutputChannel = OutputChannels.Channel02;
            brain.ChannelMask = OutputChannels.Channel02;
        }
        else if (_playerInput.playerIndex == 2)
        {
            playerCam.OutputChannel = OutputChannels.Channel03;
            brain.ChannelMask = OutputChannels.Channel03;
        }
        else if (_playerInput.playerIndex == 4)
        {
            playerCam.OutputChannel = OutputChannels.Channel04;
            brain.ChannelMask = OutputChannels.Channel04;
        }
    }
}
