 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class Foo : MonoBehaviour
 {
     public Dictionary<GameObject, Vector3> startingPositions = new Dictionary<GameObject, Vector3>();
     public static Foo instance;
 
     private void Awake() {
         instance = this;
     }
     
     public void ResetAll()
     {
         foreach(KeyValuePair<GameObject, Vector3> entry in startingPositions) {
             entry.Key.transform.position = entry.Value;
         }
     }
 }