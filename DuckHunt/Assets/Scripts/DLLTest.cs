using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.IO;


public class DLLTest : MonoBehaviour {

    [DllImport("SpawnPointsDuckHunt", EntryPoint = "GetTeamSpawnPositionSize")]
    public static extern int GetTeamSpawnPointSize();

    [DllImport("SpawnPointsDuckHunt", EntryPoint = "GetTeamSpawnPosition")]
    public static extern Vector3 GetPosition(int ID);

    [DllImport("SpawnPointsDuckHunt", EntryPoint = "GetSoloPlayerSpawnPosition")]
    public static extern Vector3 GetSoloPlayerSpawnPosition();
    

    // Use this for initialization
    void Start ()
    {
        int a = GetTeamSpawnPointSize();
        Vector3 position;

        Debug.Log("BEFOREEEEEE TEST " + a);

        for (int i = 0; i < a; i++)
        {
            position = GetPosition(i);
            Debug.Log("position " + i + " = " + GetPosition(i));
        }

        position = GetSoloPlayerSpawnPosition();
        Debug.Log("SOLO GUY: " + position);

        Debug.Log("AFTEEEEEEEEER TEST ");

    }

    // Update is called once per frame
    void Update ()
    {


    }
}
