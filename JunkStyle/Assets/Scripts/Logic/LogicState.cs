using System;
using UnityEngine;

public abstract class LogicState : MonoBehaviour
{
    [SerializeField]
    protected bool logicState;

    [SerializeField]
    protected Material[] material;

    public Action<bool> onTurnOn;

    protected abstract void Trigger(bool state);
}
