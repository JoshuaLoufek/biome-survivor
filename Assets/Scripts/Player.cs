using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // 2.22.26 - BT - Absolute basics to get movement functioning.
    private float moveSpeed = 10.0f;
    private Vector2 moveDirection;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // get the rigid body to apply force to
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // apply force. The current setup relies heavily on Linear Drag in the Inspector to "control" speed.
        // WARNING: Setting the Linear Drag to 10 or less may cause the cube to disappear into the abyss.
        // This can be tuned with moveSpeed - TODO: Discuss - terrain may effect Linear Drag (I.E. ice = slippery = lower drag = sliding)
        rb.AddForce(new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed));
    }

    public void OnMove(InputValue inputValue)
    {
        // Get the move direction from the InputSystem module. Control agnostic, should work with a controller left stick or WSAD as of 2.22.26
        moveDirection = inputValue.Get<Vector2>().normalized;
    }
}
