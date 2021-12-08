using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class MissileLauncher : MonoBehaviour
{
   public GameObject misslePrefab;
   public List<GameObject> misslePosition;
   public int missleCount;

   private Transform playerTarget;
   public Transform firePoint;
   public int randomPoint;
   public float shotDelay;
   public AudioSource sfx;

   public Vector3 worldSpace;

   private void Awake()
   {
      StartCoroutine(Lauching());
      
      //Launch();
   }
   /// <summary>
   /// This is test code that was only used to test a single missile launch. Functional code begins at Line 42.
   /// </summary>
   /// <returns></returns>
 //  private void Launch()
 //  { 
 //     Debug.Log("Launching Missiles");
 //     GameObject newMissle = Instantiate(misslePrefab, firePoint.transform.position,firePoint.transform.rotation);
 //     
 //     newMissle.GetComponent<MissileBehaviour>().SetHoldPos(misslePosition[1].transform.TransformPoint(transform.position));
 //     Debug.Log("Spawning Missile");
 //     misslePosition.RemoveAt(1);
 //    
 //  }

   public IEnumerator Lauching()
   {
      while (true)
      {
         Debug.Log("Repeating Rocket Launch");
         randomPoint = Random.Range(0, misslePosition.Count);
         //replace the below line with the function call for selecting a pooled missile.
         GameObject newMissle = Instantiate(misslePrefab, firePoint.transform.position,firePoint.transform.rotation);
         newMissle.GetComponent<MissileBehaviour>().SetHoldPos(misslePosition[randomPoint].transform.TransformPoint(transform.position));
         Debug.Log("Spawning Missile");
         sfx.Play();
         yield return new WaitForSeconds(shotDelay);
      }
   }
}
