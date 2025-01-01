using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //Movement
    private InputAction moveAction;
    public Vector2 moveVector {  get; private set; }

    //Attack
    private InputAction attackAction;
    public bool attackPressed { get; private set; }

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
        moveVector = moveAction.ReadValue<Vector2>();
        attackPressed = attackAction.WasReleasedThisFrame();
    }
}
