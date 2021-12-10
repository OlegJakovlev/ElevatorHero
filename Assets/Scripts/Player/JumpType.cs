using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Jump", menuName = "Movement/Jump")]
public class JumpType : ScriptableObject
{
    public float initalJumpForce;
    public AnimationCurve gravityRise;
    public AnimationCurve gravityFall;
    public float gravityOnRelease;

    public void StartJump()
    {

    }

    public void StopJump()
    {

    }

    public float JumpUpdate()
    {
        return 0.0f;
    }
}
