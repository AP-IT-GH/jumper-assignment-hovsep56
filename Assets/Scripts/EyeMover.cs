using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;
using Unity.MLAgents.Actuators;

public class EyeMover : Agent
{
    public TextMeshPro scoreBoard;
    Rigidbody mRigidBody;
    public float Speed = 15f;
    private bool IsGrounded;
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
        if(d > 2)
        {
            lastTime = Time.time;
            AddReward(0.1f);
        }
        // scoreBoard.text = GetCumulativeReward().ToString("f4");
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
                transform.Translate(translation, Space.World);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Debug.Log("Collide with Enemy");
            AddReward(-1);
            EndEpisode();
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
}
