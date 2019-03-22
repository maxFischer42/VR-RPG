using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CrossbowBolt : Item
{
    public enum BoltType {Fire, Plasma};
    public BoltType boltType;
    public GameObject hitPrefab;
    public Material trail;
    public int damage;
}
