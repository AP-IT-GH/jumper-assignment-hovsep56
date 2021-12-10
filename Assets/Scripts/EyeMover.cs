using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;
using Unity.MLAgents.Actuators;

public class EyeMover : Agent
{
    public TextMeshProUGUI scoreBoard;
    Rigidbody mRigidBody;
    public float Speed = 15f;
    private bool IsGrounded;

    private float time = 0;
    // public GameObject mEnemy;

    public int[] test;

    // Start is called before the first frame update

    float lastTime;

    void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var d = Time.time - lastTime;
        if(d > 1)
        {
            lastTime = Time.time;
            AddReward(0.1f);
        }
        scoreBoard.text = "Score: " + GetCumulativeReward().ToString("f4");
        time += 1 * Time.deltaTime;
        if(time > 120)
        {
            time = 0;
            EndEpisode();
        }
    }

    public override void OnEpisodeBegin()
    {
        lastTime = Time.time;
        // mEnemy.transform.localPosition = new Vector3(11, 0.75f, 0);
        transform.localPosition = new Vector3(-11, 0.5f, 0);
        transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        base.CollectObservations(sensor);
        sensor.AddObservation(transform.localPosition.y);
    }

    float rotation = 0f;
    public float rotationSpeed = 200f;
    public override void OnActionReceived(ActionBuffers vectorAction)
    {
        var action = vectorAction.DiscreteActions;
        test = action.Array;
        // Agent need to jump
        if (action[0] == 1)
        {
            if (IsGrounded)
            {
                Vector3 translation = transform.up * Speed * Time.deltaTime;
                mRigidBody.velocity = translation;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            // Debug.Log("Collide with Enemy");
            AddReward(-1);
            // EndEpisode();
        }
        if (collision.transform.CompareTag("Plane"))
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Plane"))
        {
            IsGrounded = false;
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        int movement = 0;
        if (Input.GetKey(KeyCode.Space))
        {
            movement = 1;
        }
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = movement;

    }
}
