 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class Bar : MonoBehaviour
 {
     void Start()
     {
         Foo.instance.startingPositions.Add(gameObject, transform.position);
     }
 }