using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentLogic : MonoBehaviour
{
    public GameObject redAgent;
    public GameObject blueAgent;
    public int numRedAgents;
    public int numBlueAgents;

    void Start()
    {
       CreateAgent(numRedAgents, redAgent);
       CreateAgent(numBlueAgents, blueAgent);
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
                Quaternion rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

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
                Quaternion rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

                GameObject bana = Instantiate(agent, position + transform.position, rotation);
            }
        }
    }
}
