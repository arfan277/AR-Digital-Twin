// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Net;
// using System.Net.Sockets;
// using System.Linq;
// using System;
// using System.IO;
// using System.Text; 

// public class arm_controller : MonoBehaviour

// {
//     // Set 2 floating numbers for the left and right directions
//     public float LEFT;
//     public float RIGHT;
//     public float UP;
//     public float DOWN;

//     // initialize the communication with matlab
//     // Use this for initialization
//     TcpListener listener;
//     // the msg is the value that you put in the msg matrix in matlab
//     String msg;

//     // plug in the appropriate robot parts into the inspector 
//     public Transform robotBase;
//     public Transform upperArm;

//     // adjust in the inspector for the speed of each part's rotation 
//     //public float baseTurnRate = 1.0f;
//     //public float upperArmTurnRate = 1.0f;

//     private float baseZRot = 0.0f;
//     public float baseZRotMin = -45.0f;
//     public float baseZRotMax = 45.0f;

//     private float upperArmYRot = 0.0f;
//     public float upperArmYRotMin = -45.0f;
//     public float upperArmYRotMax = 45.0f; 

//     void Start()
//     {
//         // set the floating valus for the directions. 1f is positive, while -1f is negative.
//         // each value correspondo to a direciton in the axix. for instance in the X the positive value is the right
//         // direction, while the negative value is the left
//         LEFT = 1f;
//         RIGHT = -1f;
//         UP = 1f;
//         DOWN = -1f;
//         // LISTEN TO MATLAB. Set up unity listening to matlab

//         listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 55001);
//         listener.Start();
//         print("is listening");

//     }

//     void Update()
//     {


//         if (!listener.Pending())
//         {
//         }
//         else
//         {
//             // print the message that unity is listening.
//             print("socket comes");
//             TcpClient client = listener.AcceptTcpClient();
//             NetworkStream ns = client.GetStream();
//             StreamReader reader = new StreamReader(ns);
//             msg = reader.ReadToEnd();
//             print(msg);
//         }

//         // this command allows to concatenate different if statement
//         switch (msg.ToLower())
//         {
//             // set the cilinder movement case by case depending on the mtlab inputs
//             case "1":
//             baseZRot += RIGHT; // * baseTurnRate;
//             baseZRot = Mathf.Clamp(baseZRot, baseZRotMin, baseZRotMax);
//             robotBase.localEulerAngles = new Vector3(robotBase.localEulerAngles.x, robotBase.localEulerAngles.y, baseZRot); 
//             break;
//             case "-1":
//             baseZRot += LEFT; // * baseTurnRate;
//             baseZRot = Mathf.Clamp(baseZRot, baseZRotMin, baseZRotMax);
//             robotBase.localEulerAngles = new Vector3(robotBase.localEulerAngles.x, robotBase.localEulerAngles.y, baseZRot); 
//             break;
//             case "2":
//             upperArmYRot = UP; // * upperArmTurnRate;
//             upperArmYRot = Mathf.Clamp(upperArm.localEulerAngles.x, upperArmYRot, upperArm.localEulerAngles.z);
//             upperArm.localEulerAngles = new Vector3(upperArm.localEulerAngles.x, upperArmYRot, upperArm.localEulerAngles.z);
//             break;
//             case "-2":
//             upperArmYRot = DOWN; // * upperArmTurnRate;
//             upperArmYRot = Mathf.Clamp(upperArm.localEulerAngles.x, upperArmYRot, upperArm.localEulerAngles.z);
//             upperArm.localEulerAngles = new Vector3(upperArm.localEulerAngles.x, upperArmYRot, upperArm.localEulerAngles.z);
//             break;


//         }
//     }
// }