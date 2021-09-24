using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBase : MonoBehaviour
{
    [SerializeField]
    protected float spawnDelay = 5f;
    [SerializeField]
    protected GameObject prefab;

    private float timePased = 0f;

    protected Vector2 leftDown, leftUp,
                      rightDown, rightUp;

    protected virtual void Awake() {
        leftDown   = Camera.main.ScreenToWorldPoint(
                            new Vector2(0, 0));
        leftUp     = Camera.main.ScreenToWorldPoint(
                            new Vector2(0, Screen.height));
        rightUp    = Camera.main.ScreenToWorldPoint(
                            new Vector2(Screen.width, Screen.height));
        rightDown  = Camera.main.ScreenToWorldPoint(
                            new Vector2(Screen.width, 0));
    }

    protected virtual void FixedUpdate() {
        TryToSpawn();
    }

    private void TryToSpawn(){
        timePased += Time.fixedDeltaTime;
        if(timePased > spawnDelay) {
            timePased = 0f;
            Spawn();
        }
    }
 
    protected Vector2 GetSpawnPoint() {
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

    protected virtual void Spawn() {}
}
