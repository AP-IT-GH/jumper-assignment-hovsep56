using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENV : MonoBehaviour
{
    public Vector3 offset;
    public GameObject Env;
    [Range(1,15)]
    public int total = 4;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < total; i++)
        {
            GameObject go = Instantiate(Env, transform);
            go.transform.localPosition = offset * i;
            go.name = $"{i + 1}-ENV";
        }
    }
}
