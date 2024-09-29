using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public PlayerInput playerControls;

    public delegate void InputShootDelegate(Vector3 shootDirection);
    public event InputShootDelegate OnShoot;

    InputAction move;
    InputAction fire;

    #region On Enable/Disable
    void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.canceled += Shoot;
    }

    void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }
    #endregion

    #region Unity Methods
    void Awake()
    {
        playerControls = new PlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
            
            bulletInstance.GetComponent<ShooterMechanic>().shoot(Vector3.forward);

            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);

            bulletInstance.GetComponent<ShooterMechanic>().shoot(Vector3.back);

            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);

            bulletInstance.GetComponent<ShooterMechanic>().shoot(Vector3.left);

            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);

            bulletInstance.GetComponent<ShooterMechanic>().shoot(Vector3.right);

            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }*/
    }
    #endregion

    #region Input Actions
    void Shoot(InputAction.CallbackContext context)
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = mousePos.y;
        OnShoot?.Invoke(mousePos);
    }

    public Vector3 GetMoveDirection()
    {
        // Gets 2D move direction
        Vector2 moveDirection2D = move.ReadValue<Vector2>();

        // Converts 2D direction to 3D
        Vector3 moveDirection = (Vector3)moveDirection2D;

        // Converts Y-axis direction to Z-axis direction
        if(moveDirection.y != 0)
        {
            float magnitude = moveDirection.y;
            moveDirection = Vector3.forward * magnitude;
        }

        return moveDirection;
    }
    #endregion
}
