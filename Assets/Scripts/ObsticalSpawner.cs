using UnityEngine;

public class ObsticalSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float Change = 50;
    public Vector3 offset;
    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > Random.Range(2, 20))
        {
            if(Random.Range(0, 100) < Change)
            {
                GameObject go = Instantiate(prefab, transform);
                float u = (Random.Range(0, 100) > 50) ? 0 : 4;
                go.transform.localPosition = offset + (Vector3.up * u);
            }
            timer = 0;
        }
    }
}
