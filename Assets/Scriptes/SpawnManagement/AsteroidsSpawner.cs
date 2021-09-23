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
        Vector2 direction    = GetDirection();
        float speed          = GetSpeedValue();        
        asteroidView.SetValueToInit(rotationDegree,
                                    direction, speed);
    }

    private Vector2 GetSpawnPoint() {
        int n = Random.Range(0, 3);
        
        switch(n) {
            case 0:
                return leftDown;
            case 1:
                return leftUp;
            case 2:
                return rightUp;
            case 3:
                return rightDown;
            default: return leftDown;
        }
    }

    private Vector2 GetDirection() {
        Vector2 pp = GameObject.FindWithTag("Player").transform.position;
        Vector2 sp = transform.position;

        return pp - sp;
    }

    private float GetRotationDegree() {
        return Random.Range(-90, 90);
    }

    private float GetSpeedValue() {
        return Random.Range(randomSpeedLimits.x, randomSpeedLimits.y);
    }
}
