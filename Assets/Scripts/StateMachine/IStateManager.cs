using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameStateManagement;

public abstract class IStateManager : MonoBehaviour
{
    [SerializeField]
    protected GameStateMachine stateMachine;
}
