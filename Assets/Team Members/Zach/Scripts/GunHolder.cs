using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    public List<GameObject> guns;
    public List<GameObject> gunMeshes;

    public void EnableGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.gameObject.SetActive(true);
        }
    }
}
