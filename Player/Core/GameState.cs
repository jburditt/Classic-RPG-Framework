using DataStore;
using Player.Events;
using Player.Graphics;
using Player.Inputs;
using Player.Manager;
using Player.StateStack;
using System.Collections.Generic;

namespace Player.Core
{
    public class GameState : IState
    {
        public bool Exit { get; }

        private IActorManager _actorManager;
        private IBattleManager _battleManager;
        private IDataStore _dataStore;
        private IDialogManager _dialogManager;
        private IEnemyManager _enemyManager;
        private IEventService _eventService;
        private IGraphics _graphics;
        private IIconManager _iconManager;
        private IInputManager _inputManager;
        private ISongManager _songManager;
        private ITilesetManager _tilesetManager;

        private StateMachine stateMachine = new StateMachine();
        private Dictionary<State, IState> states = new Dictionary<State, IState>();

        public GameState(
            IActorManager actorManager, IBattleManager battleManager, IDataStore dataStore, IDialogManager dialogManager, 
            IEnemyManager enemyManager, IEventService eventService, IGraphics graphics, IIconManager iconManager, IInputManager inputManager, ISongManager songManager,
            ITilesetManager tilesetManager)
        {
            _actorManager = actorManager;
            _battleManager = battleManager;
            _dataStore = dataStore;
            _dialogManager = dialogManager;
            _enemyManager = enemyManager;
            _eventService = eventService;
            _graphics = graphics;
            _iconManager = iconManager;
            _inputManager = inputManager;
            _songManager = songManager;
            _tilesetManager = tilesetManager;
        }

        public void Draw()
        {
            stateMachine.Draw();
        }

        public void OnClose()
        {
            
        }

        public void OnLoad()
        {
            var worldState = new WorldState(_dataStore, _eventService, _songManager, _graphics, _battleManager, _actorManager, _enemyManager, _iconManager, _inputManager, _tilesetManager, _dialogManager);
            states.Add(State.World, worldState);

            var menuState = new MenuState(_graphics, _dialogManager, _inputManager, _songManager);
            states.Add(State.StartMenu, menuState);

            var battleState = new BattleState(_graphics, _battleManager, _actorManager, _enemyManager, _iconManager, _inputManager, _songManager, _dialogManager, worldState);
            states.Add(State.Battle, battleState);

            stateMachine.Push(worldState);
            stateMachine.Push(menuState);
        }

        public bool Update(float elapsedTime)
        {
            if (stateMachine.Empty())
                return false;

            if (_inputManager.JustPressedKey((int)Keys.B))
            {
                stateMachine.Push(states[State.Battle]);
            }

            stateMachine.Update(elapsedTime);

            return true;
        }
    }
}
