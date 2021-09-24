using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : SpawnerBase
{
    protected override void Spawn()
    {
        Vector2 spawnPoint = GetSpawnPoint();

        Instantiate(prefab, spawnPoint, Quaternion.identity);
    }
}
