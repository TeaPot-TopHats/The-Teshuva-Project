using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NPCActions
{

    public static void Move(Rigidbody2D Rigid, Vector2 moveDirection, float speed)
    {
        Rigid.velocity = moveDirection * speed;
    }
}
