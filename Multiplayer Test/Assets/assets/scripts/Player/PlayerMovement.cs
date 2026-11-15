using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _xMovement;
    private float _zMovement;
    private float _yMovement;
    [SerializeField] private float moveSpeed;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = new Vector3(_xMovement * moveSpeed, _yMovement * moveSpeed, _zMovement * moveSpeed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _xMovement = context.ReadValue<Vector3>().x;
        _yMovement = context.ReadValue<Vector3>().y;
        _zMovement = context.ReadValue<Vector3>().z;
    }
}
