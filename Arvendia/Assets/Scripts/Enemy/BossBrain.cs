using System;
using UnityEngine;

public class BossBrain : MonoBehaviour
{
    [SerializeField] private string initState; // PatrolState
    [SerializeField] private FSMState[] states;
    [SerializeField] private ActionPatrol actionPatrol;
    
    public FSMState CurrentState { get; set; }
    public Transform Player { get; set; }
    
    private void Start()
    {
        ChangeState(initState);
    }

    private void Update()
    {

        actionPatrol.Act();
    }

    public void ChangeState(string newStateID)
    {
        FSMState newState = GetState(newStateID);
        if (newState == null) return;
        CurrentState = newState;
    }

    private FSMState GetState(string newStateID)
    {
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i].ID == newStateID)
            {
                return states[i];
            }
        }

        return null;
    }
}