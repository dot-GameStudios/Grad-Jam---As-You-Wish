using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class State : MonoBehaviour
{
    [Serializable]
    public struct Transition
    {
        public State TransitonToState; //what state to transition to
        public List<Condition> stateConditions; //holds state conditions

        public void Initialize()
        {
            for (int i = stateConditions.Count - 1; i >= 0; i--)
            {
                stateConditions[i].Initialize();
            }
        }
    }

    public bool active;
    [Header("References")]
    public Data data;

    public List<Transition> Transitions = new List<Transition>(); //holds the states that the current state can transition to

    [Header("Events")]
    public UnityEvent OnUpdate;
    public UnityEvent OnStateEnter;
    public UnityEvent OnStateExit;

    // Start is called before the first frame update
    public void Start()
    {
        for (int i = 0; i < Transitions.Count; i++)
        {
            Transitions[i].Initialize();
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (active)
        {
            OnUpdate.Invoke();
        }
    }

    public void SetActive(bool active_)
    {
        this.active = active_;
    }

    public void SetBool(string bool_, bool value_)
    {
        data.GetBool(bool_).Value = value_;
    }

    public void InvertBool(string name_)
    {
        data.GetBool(name_).Value = !data.GetBool(name_).Value;
    }

}