using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour {

    public Tilemap tilemap;
    public GameObject bombPrefab;


	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cell =  tilemap.WorldToCell(worldPos);
            Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cell);

            Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
        }
	}
}
