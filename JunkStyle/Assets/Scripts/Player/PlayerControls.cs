using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    protected CharacterController controller;
    protected PlayerInput input;
    protected static Vector3 movement;

    protected virtual void Awake()
    {
        controller = GetComponent<CharacterController>();
        input = new PlayerInput();
    }

    protected virtual void OnEnable() => input.Player.Enable();

    protected virtual void OnDisable() => input.Player.Disable();
}
