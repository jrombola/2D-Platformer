using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCommand : ICommand
{
    public void Execute()
    {
        if ((DataHolder.instance.movement.x > 0) != DataHolder.instance.facingRight)
        {
            turn();
        }
    }

    private void turn()
    {
        Vector3 scale = DataHolder.instance.gameObject.transform.localScale;
        scale.x *= -1;
        DataHolder.instance.gameObject.transform.localScale = scale;

        DataHolder.instance.facingRight = !DataHolder.instance.facingRight;
    }
}
