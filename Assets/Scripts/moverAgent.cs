using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class moverAgent : Agent
{
    public TextMeshPro scoreBoard;
    public GameObject largeObject;
    public GameObject smallObject;

    //MAKE SURE YOUR PLAYER OBJECT HAS THE DECISION REQUESTER COMPONENT!!!

    void Update()
    {
        scoreBoard.text = GetCumulativeReward().ToString("f4");

    }

    //CREATE A EPISODE, IN THIS CASE RANDOMIZE THE POSITION OF CUBES AFTER EPISODE ENDS.
    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(0, 0.5f, 0);
        float r = Random.Range(0f, 10.0f);
        if (r > 5)
        {
            largeObject.transform.localPosition = new Vector3(-4, 1.03f, 0);
            smallObject.transform.localPosition = new Vector3(4, 0.25f, 0);
        }
        else
        {
            largeObject.transform.localPosition = new Vector3(4, 1.03f, 0);
            smallObject.transform.localPosition = new Vector3(-4, 0.25f, 0);
        }

        //base.OnEpisodeBegin();
    }

    //GIVE THE AI SENSORS BASED ON THE AMOUNT WRITTEN IN BEHAVIOR PARAMETERS (SPACE SIZE)
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(largeObject.transform.localPosition.x);
        sensor.AddObservation(smallObject.transform.localPosition.x);
        sensor.AddObservation(largeObject.transform.localScale.y);
        sensor.AddObservation(smallObject.transform.localScale.y);
    }


    //TELL WHAT ACTION DOES WHAT AMOUNT OF ACTIONS DEPEND ON WHAT IS WRITTEN IN BEHAVIOR PARAMETER(ACTIONS,BRANCHES,SIZE(ACTIONBUFFER REQUIRED))
    public override void OnActionReceived(ActionBuffers vectorAction) {
        var action = vectorAction.DiscreteActions;
        
        switch(action[0]) {
            case 1:
                transform.localPosition += new Vector3(1 * Time.deltaTime, 0, 0);
                break;
            case 2:
                transform.localPosition -= new Vector3(1 * Time.deltaTime, 0, 0);
                break;
            default:
                AddReward(-0.001f);
                break;
        }
    }

    //GIVE MANUAL CONTROLS TO SEE WETHER REWARDS WORK(THE USE OF ACTIONBUFFER IS REQUIRED ITS IMPORTED FROM Unity.MLAgents.Actuators;)
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        int movement = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement = 2;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movement = 1;
        }
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = movement;

    }

    //WHAT WILL HAPPEN IF ONE OR THE OTHER CUBE GETS TOUCHED BY THE AI
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("large"))
        {
            AddReward(1);
            EndEpisode();
        }

        if (collision.transform.CompareTag("small"))
        {
            AddReward(-0.5f);
        }
    }
}
