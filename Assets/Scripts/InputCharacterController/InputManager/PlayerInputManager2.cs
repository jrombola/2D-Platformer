using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInputManager2 : MonoBehaviour
{
    private List<ActionObject> inputBuffer = new List<ActionObject>();
    private bool ActionAllowed;

    public bool JumpButtonDown;
    public bool JumpButtonHeld;

    public int count;
   

    MoveCommand Move = new MoveCommand();
    TurnCommand Turn = new TurnCommand();
    SlideCommand Slide = new SlideCommand();

    private void Update()
    {
        //Debug.Log(inputBuffer.Count);
        count = inputBuffer.Count;
        tryBufferedAction();
        DataHolder.instance.movement.x = Input.GetAxisRaw("Horizontal");
        JumpButtonDown = Input.GetKeyDown(KeyCode.Space);
        JumpButtonHeld = Input.GetKey(KeyCode.Space);

        if (JumpButtonDown)
            inputBuffer.Add(new ActionJump());

        if (!JumpButtonHeld && DataHolder.instance.isJumping)
            inputBuffer.Add(new ActionJumpCut());
        

    }

    private void FixedUpdate()
    {
        if(DataHolder.instance.movement.x != 0)
            Turn.Execute();
        Slide.Execute();
        Move.Execute();
        
    }

    private void tryBufferedAction()
    {
        if(inputBuffer.Count > 0)
        {
            for (int i = 0; i < inputBuffer.Count; i++)
            {
                if (inputBuffer[i].CheckAction())
                {
                    inputBuffer[i].ExecuteAction();
                    inputBuffer.Remove(inputBuffer[i]);
                }
                else if(inputBuffer[i].checkTime() < Time.time)
                {
                    inputBuffer.RemoveAt(i);
                }

            }        
        }
    }
}
