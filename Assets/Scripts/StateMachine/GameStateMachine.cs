using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace GameStateManagement
{
    public class GameStateMachine : MonoBehaviour
    {
        public static GameStateMachine Instance;
        private GameState[] stateOrder = { GameState.Intro, GameState.Card, GameState.Placement, GameState.Effect };
       
        private GameState currentState = GameState.Intro;
        /// <summary>
        /// The current state we are in.
        /// </summary>
        public GameState CurrentState { get { return currentState;} }
        
        /// <summary>
        /// registers unity action events to a new state
        /// </summary>
        private Dictionary<GameState, List<UnityAction>> stateEventRegister = new Dictionary<GameState, List<UnityAction>>();
        private Dictionary<GameState, List<UnityAction>> stateExitEventRegister = new Dictionary<GameState, List<UnityAction>>();
        /// <summary>
        /// Gets you the previous state.
        /// </summary>
        public GameState PreviousState { 
            get { 
                int curIndex = System.Array.IndexOf(stateOrder, currentState);
                curIndex= Mathf.Max(curIndex-1, 0);
                return stateOrder[curIndex];
            } 
        }
        /// <summary>
        /// Gets you the next state.
        /// </summary>
        public GameState NextState
        {
            get
            {
                int curIndex = System.Array.IndexOf(stateOrder, currentState);
                curIndex = Mathf.Min(curIndex + 1, stateOrder.Length-1);
                return stateOrder[curIndex];
            }
        }

        private void Awake()
        {
            foreach(GameState state in stateOrder)
            {
                stateEventRegister.Add(state, new List<UnityAction>());
                stateExitEventRegister.Add(state,new List<UnityAction>());
            }
            Instance = this;
            
        }

       
        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        /// <summary>
        /// Iterates to the next state.
        /// </summary>
        public void Next()
        {
            foreach(UnityAction action in stateExitEventRegister[this.currentState])
            {
                action.Invoke();
            }
            this.currentState = NextState;
            foreach(UnityAction action in stateEventRegister[this.currentState])
            {
                action.Invoke();
            }
        }
        /// <summary>
        /// Iterates to the previous state.
        /// </summary>
        public void Previous()
        {
            foreach (UnityAction action in stateExitEventRegister[this.currentState])
            {
                action.Invoke();
            }
            this.currentState = PreviousState;

            foreach (UnityAction action in stateEventRegister[this.currentState])
            {
                action.Invoke();
            }
        }
        /// <summary>
        /// Register a callback function to this current state.
        /// </summary>
        /// <param name="state">The state we are entering.</param>
        /// <param name="function">The function we want to call when we enter this state.</param>
        public void RegisterEnterStateEvent(GameState state, UnityAction function)
        {
            this.stateEventRegister[state].Add(function);
        }
        public void RegisterExitStateEvent(GameState state, UnityAction function)
        {
            this.stateExitEventRegister[state].Add(function);
        }
        
    }

    public enum GameState { Intro, Card, Placement, Effect }
}
