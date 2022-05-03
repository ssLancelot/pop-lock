using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawner : MonoBehaviour
{
    public AnchorMotor _motor;
    public GameObject DotPrefab;
    public GameObject StarredDotPrefab;
    public GameData Gamedata;

    GameObject _firstDot;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        RemoveDuplicates();

        var angle = Random.Range(Gamedata.MinSpawnAngle, Gamedata.MaxSpawnAngle);
        var go = Instantiate(SelectRandomDot(), _motor.transform.position, Quaternion.identity, transform);
        go.transform.RotateAround(transform.position, Vector3.forward, -angle * (int)_motor.Direction);
    }

    GameObject SelectRandomDot()
    {
        if (Random.value < 0.2f) { return StarredDotPrefab; } else { return DotPrefab; }
    }

    void RemoveDuplicates()
    {
        var dots = GameObject.FindGameObjectsWithTag("Dot");
        foreach (var dot in dots)
        {
            Destroy(dot);
        }
    }
}
