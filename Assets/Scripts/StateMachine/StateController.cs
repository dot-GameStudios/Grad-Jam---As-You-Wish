using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [Header("States")]
    [SerializeField] private State[] states; //holds all the states in the machine

    [Header("Current State")]
    [SerializeField] private State currentState; //holds the currently active state

    // Start is called before the first frame update
    void Start()
    {
        if (states.Length <= 0)
        {
            Debug.Log("You need a state for the state controller");
        }
        else
        {
            currentState = states[0];
            currentState.SetActive(true);
            currentState.OnStateEnter.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        EvaluateStateTransition(currentState);
    }

    public void EvaluateStateTransition(State state_)
    {
        for (int i = state_.Transitions.Count - 1; i >= 0; i--)
        {
            for(int j = state_.Transitions[i].stateConditions.Count - 1; j >=0; j--)
            {
                if (state_.Transitions[i].stateConditions[j].Evaluate())
                {
                    TransitionTo(state_.Transitions[i].TransitonToState);
                }
            }
        }
    }

    void TransitionTo(State state_) {
        currentState.SetActive(false);
        currentState.OnStateExit.Invoke();

        state_.OnStateEnter.Invoke();
        state_.SetActive(true);

        currentState = state_;
    }
}
