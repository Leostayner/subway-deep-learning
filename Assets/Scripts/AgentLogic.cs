using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class AgentLogic : MonoBehaviour
{
    public GameObject redAgent;
    public GameObject blueAgent;
    
    SubwayAcademy academy;
    int numAgents;

    void Start()
    {
    academy = FindObjectOfType<SubwayAcademy>();
    numAgents = (int)academy.resetParameters["MultiAgents"];
    
    }

    void CreateAgent(int numAgents, GameObject agent)
    {
        if(agent.CompareTag("redAgent"))
        {
            for (int i = 0; i < numAgents; i++)
            {
                float xPos = Random.Range(-4.5f, -0.5f);
                float zPos = Random.Range(-4f, 4f);

                Vector3 position = new Vector3(xPos, 0.25f, zPos);
                Quaternion rotation = Quaternion.Euler(0f, 90f, 0f);

                GameObject bana = Instantiate(agent, position + transform.position, rotation);
            }
        }
        else
        {
            for (int i = 0; i < numAgents; i++)
            {
                float xPos = Random.Range(0.5f, 4.5f);
                float zPos = Random.Range(-4f, 4f);

                Vector3 position = new Vector3(xPos, 0.25f, zPos);
                Quaternion rotation = Quaternion.Euler(0f, -90f, 0f);

                GameObject bana = Instantiate(agent, position + transform.position, rotation);
            }
        }
    }

    void Update()
    {
        if(numAgents != (int)academy.resetParameters["MultiAgents"])
        {
            numAgents = (int)academy.resetParameters["MultiAgents"];
            CreateAgent(1, redAgent);
            CreateAgent(1, blueAgent);

        }
    }
}
