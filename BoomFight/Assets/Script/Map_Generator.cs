using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Generator : MonoBehaviour
{
    [SerializeField]
    GameObject Ground;

    [SerializeField]
    GameObject Wall;

    [SerializeField]
    protected int width = 11;

    [SerializeField]
    protected int length = 11;

    //width och lenght behöver vara ojämna (10 -> 11)

    protected int height = 1;

    protected float offset = 10f;

    void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < length; z++)
            {
                GameObject newTile = Instantiate(Ground);

                newTile.transform.position = new Vector3(x, 0, z) * 10;

                newTile.name = "Ground(" + x.ToString() + ", " + z.ToString() + ")";

                newTile.transform.parent = this.transform;

                if (x == 0 || z == 0)
                {
                    PlaceWall(offset, x, z);
                }
                else if (x == width - 1 || z == length - 1)
                {
                    PlaceWall(offset, x, z);
                }
                else if (x % 2 == 0 && z % 2 == 0)
                {
                    PlaceWall(offset, x, z);
                }
            }
        }
    }

    protected void PlaceWall(float offset, int x, int z)
    {
        GameObject newTile = Instantiate(Wall);

        newTile.transform.position = new Vector3(x, height, z) * 10;

        newTile.name = "Wall(" + x.ToString() + ", " + z.ToString() + ")";

        newTile.transform.parent = this.transform;
    }

}
