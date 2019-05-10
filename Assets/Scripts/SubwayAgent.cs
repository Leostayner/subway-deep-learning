﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class SubwayAgent : Agent
{
    public GameObject ground;
    public GameObject redGoal;

    RayPerception rayPer;
    Rigidbody agentRB;
    Material groundMaterial;
    Renderer groundRenderer;
    SubwayAcademy academy;

    public override void InitializeAgent()
    {
        base.InitializeAgent();
        academy = FindObjectOfType<SubwayAcademy>();
        rayPer = GetComponent<RayPerception>();
        agentRB = GetComponent<Rigidbody>();
        groundRenderer = ground.GetComponent<Renderer>();
        groundMaterial = groundRenderer.material;
    }

    public override void CollectObservations()
    {
        float rayDistance = 12f;
        float[] rayAngles = { 20f, 60f, 90f, 120f, 160f };
        string[] detectableObjects = { "redGoal", "wall" };
        AddVectorObs(GetStepCount() / (float)agentParameters.maxStep);
        AddVectorObs(rayPer.Perceive(rayDistance, rayAngles, detectableObjects, 0f, 0f));
    }

    IEnumerator GoalScoredSwapGroundMaterial(Material mat, float time)
    {
        groundRenderer.material = mat;
        yield return new WaitForSeconds(time);
        groundRenderer.material = groundMaterial;
    }

    public void MoveAgent(float[] act)
    {
        Vector3 dirToGo = Vector3.zero;
        Vector3 rotateDir = Vector3.zero;

        if (brain.brainParameters.vectorActionSpaceType == SpaceType.continuous)
        {
            dirToGo = transform.forward * Mathf.Clamp(act[0], -1f, 1f);
            rotateDir = transform.up * Mathf.Clamp(act[1], -1f, 1f);
        }
        else
        {
            int action = Mathf.FloorToInt(act[0]);
            switch (action)
            {
                case 1:
                    dirToGo = transform.forward * 1f;
                    break;
                case 2:
                    dirToGo = transform.forward * -1f;
                    break;
                case 3:
                    rotateDir = transform.up * 1f;
                    break;
                case 4:
                    rotateDir = transform.up * -1f;
                    break;
            }
        }
        transform.Rotate(rotateDir, Time.deltaTime * 150f);
        agentRB.AddForce(dirToGo * academy.agentRunSpeed, ForceMode.VelocityChange);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        AddReward(-1f / agentParameters.maxStep);
        MoveAgent(vectorAction);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("redGoal") || col.gameObject.CompareTag("wall"))
        {
            if (col.gameObject.CompareTag("redGoal"))
            {
                SetReward(1f);
                StartCoroutine(GoalScoredSwapGroundMaterial(academy.goalScoredMaterial, 0.5f));
            }
            else
            {
                SetReward(-0.1f);
                StartCoroutine(GoalScoredSwapGroundMaterial(academy.failMaterial, 0.5f));
            }
            Done();
        }
    }

    public override void AgentReset()
    {
        agentRB.velocity *= 0f;
        transform.position = new Vector3(-5f, 0.5f, Random.Range(-3f, 3f)) + ground.transform.position;
        transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
        
    }
}