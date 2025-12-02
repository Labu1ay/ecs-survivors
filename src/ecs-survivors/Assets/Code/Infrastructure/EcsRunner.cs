using System;
using Code.Gameplay;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class EcsRunner : MonoBehaviour
    {
        [Inject] private readonly GameContext _gameContext;
        [Inject] private readonly ITimeService _timeService;
        [Inject] private readonly IInputService _inputService;
        [Inject] private readonly ICameraProvider _cameraProvider;
        
        private BattleFeature _battleFeature;

        private void Start()
        {
            _battleFeature = new BattleFeature(_gameContext, _timeService, _inputService, _cameraProvider);
            _battleFeature.Initialize();
        }

        private void Update()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        private void OnDestroy()
        {
            _battleFeature.TearDown();
        }
    }
}