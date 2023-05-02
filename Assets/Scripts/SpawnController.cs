using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    // We are on a flat plane right now so we can always spawn at this height
    // TODO: This will have to be changed when not on a flat plane
    const float Y_POSITION = 0.5f;

    public GameObject antPrefab;
    public GameObject foodPrefab;
    public GameObject hivePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Left mouse click
            SpawnPrefabAtMousePosition(antPrefab);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // Right mouse click
            SpawnPrefabAtMousePosition(foodPrefab);
        }
        else if (Input.GetMouseButtonDown(2))
        {
            // Middle mouse click
            SpawnPrefabAtMousePosition(hivePrefab);
        }
    }


    // spawn prefab at mouse position with random rotation
    private void SpawnPrefabAtMousePosition(GameObject prefab)
    {
        SpawnPrefab(prefab, Input.mousePosition, Random.Range(0.0f, 360.0f));
    }

    // spawn prefab at given position and rotation
    // TODO: rotation will have be updated when terrain is not flat
    private void SpawnPrefab(GameObject prefab, Vector3 position, float rotationInDegrees)
    {
        position = Camera.main.ScreenToWorldPoint(position);
        position.y = Y_POSITION;
        Instantiate(prefab, position, Quaternion.Euler(new Vector3(0.0f, rotationInDegrees, 0.0f)));
    }
}
