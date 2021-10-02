using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    public GameObject houseTemplate;
    public Terrain terrain;
    public float cellSize = 10;
    public float gap = 3;
    public float size = 1000;

    public Vector3 MinScale = Vector3.one * 0.5f;
    public Vector3 MaxScale = Vector3.one * 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        int count = (int)(size / cellSize);

        for (int x = 0; x < count; x++)
        {
            for (int z = 0; z < count; z++)
            {
                var position = new Vector3(
                    x * cellSize + Random.Range(gap, cellSize),
                    0,
                    z * cellSize + Random.Range(gap, cellSize));
                position.y = terrain.SampleHeight(position);


                var scale = new Vector3(
                    Random.Range(MinScale.x, MaxScale.x),
                    Random.Range(MinScale.y, MaxScale.y),
                    Random.Range(MinScale.z, MaxScale.z)
                );

                var duplicate = Instantiate(houseTemplate, transform);
                duplicate.GetComponent<Transform>().localPosition = position;
                duplicate.GetComponent<Transform>().localScale = scale;
                duplicate.SetActive(true);
            }
        }

        houseTemplate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
