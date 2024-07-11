using UnityEngine;

public class LogicReceiver : LogicState
{
    [SerializeField]
    private LogicState previousComponent;

    protected override void Trigger(bool state)
    {
        logicState = state;
        onTurnOn?.Invoke(logicState);

        if (logicState) GetComponent<MeshRenderer>().material.color = material[1].color;
        else GetComponent<MeshRenderer>().material.color = material[0].color;
    }

    private void OnEnable() => previousComponent.onTurnOn += Trigger;

    private void OnDisable() => previousComponent.onTurnOn -= Trigger;
}
