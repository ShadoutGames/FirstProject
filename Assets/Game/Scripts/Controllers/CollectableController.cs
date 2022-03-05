using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    [SerializeField]
    private Transform collectableParent;

    [SerializeField]
    private CollectableType[] collectables;




    private void Start()
    {
        foreach (var collectable in collectables)
        {
            SpawnLoop(collectable);
        }
    }

    private void SpawnLoop(CollectableType collectableType)
    {
        float xPosition = Random.Range
        (
            -MapController.Instance.MapSize.x * 5,
            MapController.Instance.MapSize.x * 5
        );
        float zPosition = Random.Range
        (
            -MapController.Instance.MapSize.y * 5, 
            MapController.Instance.MapSize.y * 5
        );

        GameObject spawnObject = Instantiate
        (
            collectableType.Prefab, 
            new Vector3(xPosition, 0, zPosition), 
            Quaternion.identity, 
            collectableParent
        );

        LeanTween.delayedCall(collectableType.SpawnTime, () => SpawnLoop(collectableType));
    }

}

[System.Serializable]
struct CollectableType
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float spawnTime;

    public GameObject Prefab => prefab;
    public float SpawnTime => spawnTime;
}
