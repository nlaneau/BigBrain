using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> _objects;
    public GameObject _bottomPlatform;

    private float MaxXPos;
    private float MinXPos;

    // Start is called before the first frame update
    void Start()
    {
        var platformCollider = _bottomPlatform.GetComponent<BoxCollider2D>();

        MaxXPos = platformCollider.bounds.max.x;
        MinXPos = platformCollider.bounds.min.x;
    }

    private int FrameCount = 0;

    // Update is called once per frame
    void Update()
    {
        // Every X frames, spawn a new random object
        if (FrameCount % Config.ITEM_SPAWN_RATE == 0)
        {
            SpawnObject();
            FrameCount = 0;
        }

        FrameCount++;
    }

    private void SpawnObject()
    {
        var spawnedObj = Instantiate(_objects[Random.Range(0, _objects.Count)]);

        // Set new objects position to be a constant Y above BottomPlatform, but random X
        var yPos = _bottomPlatform.transform.position.y + Config.ITEM_SPAWN_HEIGHT;
        var xPos = Random.Range(MinXPos, MaxXPos);

        spawnedObj.transform.position = new Vector2(xPos, yPos);
    }
}
