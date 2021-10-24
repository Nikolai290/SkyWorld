using Assets.Scripts.Common.Consts;
using Assets.Scripts.Environment.Parameters;
using Assets.Scripts.Global;
using Assets.Scripts.Player;
using Assets.Scripts.Player.FuelSystem;
using SkyWorld.Environment;
using SkyWorld.Environment.Parameters;
using SkyWorld.Global;
using SkyWorld.InputSystem;
using SkyWorld.Player;
using SkyWorld.Player.Parameters;
using UnityEngine;
using Zenject;

namespace Assets.Scenes.DevScene.Scripts {
    public class DevSceneInstaller : MonoInstaller {
        // In game scene objects
        private GameObject _player;
        private GameObject _mainCamera;
        private GameObject _worldBorders;
        private GameObject _gamepadArea;
        private GameObject _healthBar;
        private GameObject _fuelIndicator;
        private GameObject _gameCoinsManager;
        private GameObject _gameScoreManager;

        // Sctiptable object resources
        [SerializeField] private PlayerParameters _playerParameters;
        [SerializeField] private CameraParameters _cameraParameters;
        [SerializeField] private WorldParameters _worldParameters;

        public override void InstallBindings() {
            _player = GameObject.FindWithTag(Tags.PLAYER);
            _mainCamera = GameObject.FindWithTag(Tags.MAIN_CAMERA);
            _worldBorders = GameObject.FindWithTag(Tags.WORLD_BORDERS);
            _gamepadArea = GameObject.Find(Names.GAMEPAD_AREA);
            _healthBar = GameObject.Find(Names.HEALTH_BAR);
            _fuelIndicator = GameObject.Find(Names.FUEL_INDICATOR);
            _gameCoinsManager = GameObject.Find(Names.GAME_COINS_MANAGER);
            _gameScoreManager = GameObject.Find(Names.GAME_SCORE_MANAGER);


            Container.Bind<IPlayerMovement>().To<PlayerMovement>().FromComponentOn(_player).AsSingle();
            Container.Bind<CameraMovementV2>().FromComponentOn(_mainCamera).AsSingle();
            Container.Bind<WorldBorders>().FromComponentOn(_worldBorders).AsSingle();
            Container.Bind<GamePad>().FromComponentOn(_gamepadArea).AsSingle();
            Container.Bind<HealthBar>().FromComponentOn(_healthBar).AsSingle();
            Container.Bind<FuelIndicator>().FromComponentOn(_fuelIndicator).AsSingle();
            Container.Bind<GameCoins>().FromComponentOn(_gameCoinsManager).AsSingle();
            Container.Bind<GameScore>().FromComponentOn(_gameScoreManager).AsSingle();


            Container.Bind<CameraParameters>().FromScriptableObject(_cameraParameters).AsSingle();
            Container.Bind<PlayerParameters>().FromScriptableObject(_playerParameters).AsSingle();
            Container.Bind<WorldParameters>().FromScriptableObject(_worldParameters).AsSingle();
        }
    }
}