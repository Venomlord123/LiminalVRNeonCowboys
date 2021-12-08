using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPosition : MonoBehaviour
{
    public void AddPoint() => BossMovement.AddPoint(transform);
}
