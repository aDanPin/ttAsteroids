using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject shard;
    [SerializeField]
    private float addedSpeed;

    private void Start() {
        GameEvents.current.onAsteroidDestroyTriggerEnter += Spawn;
    }

    private void Spawn(Vector2 pos, float speed) {
        var shard1View = Instantiate(shard, transform.position, Quaternion.identity)
                             .GetComponent<IPhisicalView>();
        var shard2View = Instantiate(shard, transform.position, Quaternion.identity)
                             .GetComponent<IPhisicalView>();

        float shardSpeed = speed + addedSpeed;

        float rotationDegree1 = Random.Range(0f, 360f);
        Vector2 direction1    = Utils.Rotate(Vector2.up, Random.Range(0, 360));
        shard1View.SetValueToInit(rotationDegree1,
                                  direction1, speed);

        float rotationDegree2 = Random.Range(0f, 360f);
        Vector2 direction2    = Utils.Rotate(Vector2.up, Random.Range(0, 360));
        shard2View.SetValueToInit(rotationDegree2,
                                  direction2, speed);
    }
}
