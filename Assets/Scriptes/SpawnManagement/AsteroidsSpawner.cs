using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawner : SpawnerBase
{
    [SerializeField]
    private Vector2 randomSpeedLimits = new Vector2(10, 15); 

    protected override void Spawn()
    {
        Vector2 spawnPoint = GetSpawnPoint();

        var asteroid = Instantiate(prefab, spawnPoint, Quaternion.identity);
        var asteroidView = asteroid.GetComponent<IPhisicalView>();

        float rotationDegree = GetRotationDegree();
        Vector2 direction    = GetDirection(spawnPoint);
        float speed          = GetSpeedValue();        
        asteroidView.SetValueToInit(rotationDegree,
                                    direction, speed);
    }

    private Vector2 GetDirection(Vector2 sp) {
        Vector2 pp = GameObject.FindWithTag("Player").transform.position;

        return pp - sp;
    }

    private float GetRotationDegree() {
        return Random.Range(-90, 90);
    }

    private float GetSpeedValue() {
        return Random.Range(randomSpeedLimits.x, randomSpeedLimits.y);
    }
}
