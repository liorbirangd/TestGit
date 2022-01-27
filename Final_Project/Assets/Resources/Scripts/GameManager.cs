using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public LayerMask platformLayer;

    //object references
    private Player player;

    //game state variables
    private bool isOverworldActive = true;

    //input variables
    private float moveInput = 0;
    private bool jumpInput = false;
    // Start is called before the first frame update
    void Start()
    {
        LocateGameObjects();
    }
    private void LocateGameObjects()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        CurrentInput();
        if(isOverworldActive) PlayerMovement();
    }
    private void CurrentInput()
    {
        moveInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetKeyDown(KeyCode.Space);
    }
    private void PlayerMovement()
    {
        player.MoveX(moveInput);
        if (jumpInput)
        {
            Debug.Log("jump");
            player.Jump();
        }
    }
    private void ManageExceptions(Exception e)
    {

    }
}
