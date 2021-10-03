using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    public GameObject houseTemplate;
    public GameObject[] treeTemplates;

    public Terrain terrain;
    public float cellSize = 10;
    public float gap = 3;
    public float size = 1000;

    public int treeSubcells = 5;

    public Vector3 MinScale = Vector3.one * 0.5f;
    public Vector3 MaxScale = Vector3.one * 1.5f;

    public float globalHouseScaling = 1;
    public float globalTreeScaling = 1;

    // Start is called before the first frame update
    void Start()
    {
        int count = (int)(size / cellSize);

        for (int x = 0; x < count; x++)
        {
            for (int z = 0; z < count; z++)
            {
                var cellPosition = new Vector3(
                    x * cellSize,
                    0,
                    z * cellSize);

                var position = cellPosition + new Vector3(
                    Random.Range(gap, cellSize),
                    0,
                    Random.Range(gap, cellSize));
                position.y = terrain.SampleHeight(position);


                var scale = new Vector3(
                    Random.Range(MinScale.x, MaxScale.x),
                    Random.Range(MinScale.y, MaxScale.y),
                    Random.Range(MinScale.z, MaxScale.z)
                ) * globalHouseScaling;

                var house = Instantiate(houseTemplate, transform);
                house.transform.localPosition = position;
                house.transform.localScale = scale;
                house.transform.localRotation = Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.up);
                house.SetActive(true);


                var treeCellSize = cellSize / treeSubcells;
                var treeGap = gap / treeSubcells;
                for (int tree_x = 0; tree_x < treeSubcells; tree_x++)
                {
                    for (int tree_z = 0; tree_z < treeSubcells; tree_z++)
                    {
                        var tree = Instantiate(treeTemplates[Random.Range(0, treeTemplates.Length)], transform);

                        var treePos = cellPosition + new Vector3(
                            tree_x * treeCellSize + Random.Range(treeGap, treeCellSize),
                            0,
                            tree_z * treeCellSize + Random.Range(treeGap, treeCellSize));
                        treePos.y = terrain.SampleHeight(treePos);
                        tree.transform.localPosition = treePos;

                        tree.transform.localRotation = Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.up);
                        tree.transform.localScale = Vector3.one * globalTreeScaling;
                    }
                }
            }
        }
    }
}
