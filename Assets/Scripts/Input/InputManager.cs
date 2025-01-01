using Unity.Burst;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //Movement
    private InputAction moveAction;
    public static readonly SharedStatic<Vector2> moveVector = SharedStatic<Vector2>.GetOrCreate<InputManager, Vector2FieldKey>();
    private class Vector2FieldKey { }

    //Attack
    private InputAction attackAction;
    public static readonly SharedStatic<bool> attackPressed = SharedStatic<bool>.GetOrCreate<InputManager, BoolFieldKey>();
    private class BoolFieldKey { }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Define constant
        const string ACTION_MOVE = "Move";
        const string ACTION_ATTACK = "Attack";
        
        //Find action
        moveAction = InputSystem.actions.FindAction(ACTION_MOVE);
        attackAction = InputSystem.actions.FindAction(ACTION_ATTACK);
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.Data = moveAction.ReadValue<Vector2>();
        attackPressed.Data = attackAction.WasReleasedThisFrame();
    }
}
