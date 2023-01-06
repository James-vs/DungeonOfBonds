using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // current state to be played in state machine 
    public State currentState;

    // Update is called once per frame
    void Update()
    {
        //start state machine
        RunStateMachine();
    }

    private void RunStateMachine() {
        // if current state not null, assign state to nextState
        State nextState = currentState?.RunCurrentState();

        // if next state not null, run next state 
        if (nextState != null) {
            SwitchToNextState(nextState);
        }
    }

    // method to change current state 
    private void SwitchToNextState(State nextState) {
        currentState = nextState;
    }
}
