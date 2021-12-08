using UnityEngine;

public class ObsticalSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if(Time.time % 2 == 0)
        {
            if(Random.Range(0, 100) > 50)
            {
                GameObject go = Instantiate(prefab, transform);
                go.transform.localPosition = offset;
            }
        }
    }
}
