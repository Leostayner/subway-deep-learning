using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class SubwayAcademy : Academy
{
    public float agentRunSpeed;
    public float agentRotationSpeed;
    public Material goalScoredMaterial; // when a goal is scored the ground will use this material for a few seconds.
    public Material failMaterial; // when fail, the ground will use this material for a few seconds. 
    public float gravityMultiplier = 2.5f; // use ~3 to make things less floaty

    public override void InitializeAcademy()
    {
        Physics.gravity *= gravityMultiplier;
    }

    public override void AcademyReset(){}
}
