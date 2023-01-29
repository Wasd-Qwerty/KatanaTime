using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class FruitInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject[] _fruits;
    [SerializeField] private Transform[] _fruitsSpawnPos;
    public TrackTime trackTime;
    public void Inst()
    {
        trackTime.timeInst = Time.time;
        var pos = _fruitsSpawnPos[Random.Range(0, _fruitsSpawnPos.Length)];
        var fruit = _fruits[Random.Range(0, _fruits.Length)];
        Instantiate(fruit,pos.position, Quaternion.identity);
    }
}
