using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System;
using System.IO;
using System.Text; 

public class csv_reader : MonoBehaviour 
{
    public TextAsset textAssetData;
    [System.Serializable]
    public class Joint 
    {
        public int angle_j1;
        public int angle_j2;
        public int angle_j3; 
    }
    [System.Serializable]
    public class JointList
    {
        public Joint[] joint;

    }
    public JointList myJointList = new JointList();

    void Start()
    {
        ReadCSV();

    }

    void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] {",","\n"}, StringSplitOptions.None );
        int tableSize = data.Length / 3 - 1;
        myJointList.joint = new Joint[tableSize];

        for(int i = 0; i < tableSize; i++)
        {
            myJointList.joint[i] = new Joint();
            myJointList.joint[i].angle_j1 = int.Parse(data[3 * (i+1)]);
            myJointList.joint[i].angle_j2 = int.Parse(data[3 * (i+1) + 1]);
            myJointList.joint[i].angle_j3 = int.Parse(data[3 * (i+1) + 2]);
        }
    }
}

