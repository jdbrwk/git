using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour {

    public float Speed;
    public Tilemap tilemap;
    public GameObject bombPrefab;
   
    private Rigidbody2D player;

	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        player.AddForce(movement * Speed);
	}

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector3 playerPos = player.transform.position;
            //Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cell = tilemap.WorldToCell(playerPos);
            Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cell);

            Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
        }
    }

    //Vector3 SnapToTile(Vector3 cellCenterPos)
    //{
    //    Vector3 playerPos = player.transform.position;
    //    //Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    Vector3Int cell = tilemap.WorldToCell(playerPos);
    //    Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cell);
    //    return cellCenterPos;
    //}
}
