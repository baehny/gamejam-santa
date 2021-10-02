using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    public GameObject houseTemplate;
    public Terrain terrain;

    // Start is called before the first frame update
    void Start()
    {
        float cellSize = 10;
        float gap = 3;

        for (int x = 0; x < 100; x++)
        {
            for (int z = 0; z < 100; z++)
            {
                var position = new Vector3(
                    x * cellSize + Random.Range(gap, cellSize),
                    0,
                    z * cellSize + Random.Range(gap, cellSize));
                position.y = terrain.SampleHeight(position);

                var duplicate = Instantiate(houseTemplate);
                duplicate.GetComponent<Transform>().position = position;
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
