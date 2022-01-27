using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpSpeed = 5;
    [SerializeField] private int airJumpNum = 1;
    private float groundExtraHeight = 0.1f;
    //object references
    private GameManager manager;
    //component references
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _collider;
    //object state veriables
    private bool isFacingRight;
    private int airJumpCount;
    // Start is called before the first frame update
    void Start()
    {
        LocateGameObjects();
    }
    private void InitializeStateVariables()
    {
        isFacingRight = true;
        airJumpCount = airJumpNum;
    }
    private void LocateGameObjects()
    {
        manager = FindObjectOfType<GameManager>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            airJumpCount = airJumpNum;
        }
    }
    public void MoveX(float direction)
    {
        if ((isFacingRight && direction > 0) || (!isFacingRight && direction < 0))
        {
            MirrorAnimation();
        }
        _rigidBody.velocity=new Vector2(moveSpeed*direction,_rigidBody.velocity.y);
    }
    public void Jump()
    {
        if (IsGrounded())
        {
            Debug.Log("Player.Jump()");
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x,jumpSpeed);
        }
        else if(airJumpCount>0)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, jumpSpeed);
            airJumpCount -= 1;
        }
    }
    private void MirrorAnimation()
    {
        isFacingRight = !isFacingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private bool IsGrounded()
    {
        RaycastHit2D ray= Physics2D.Raycast(_collider.bounds.center, Vector2.down,_collider.bounds.extents.y+groundExtraHeight,manager.platformLayer);
        return ray.collider!=null;
    }
}
