using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Enter();
    void Tick();//update without mono
    void FixedTick();//fixed update without mono
    void Exit();
}

