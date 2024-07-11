using UnityEngine;

public class LogicSource : LogicState
{
    private bool activated;

    private void Update()
    {
        if (logicState) Trigger(false);
        else Trigger(true);
    }

    protected override void Trigger(bool condition)
    {
        if (activated == condition)
        {
            activated = !activated;
            onTurnOn?.Invoke(logicState);
        }

        if (logicState) GetComponent<MeshRenderer>().material.color = material[1].color;
        else GetComponent<MeshRenderer>().material.color = material[0].color;
    }
}
