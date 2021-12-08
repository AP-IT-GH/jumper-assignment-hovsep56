using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform currentobject;
    [SerializeField]
    private float speed = -1;
    Vector3 position;
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        position = currentobject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y < -1f)
        {
            currentobject.transform.position = position;
            Destroy(gameObject);
        }
        body.velocity = new Vector3(0, 0, 0);
        currentobject.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // currentobject.transform.position = position;
        }

    }

}
