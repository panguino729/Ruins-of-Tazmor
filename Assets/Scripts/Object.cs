using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public static List<Object> objects; //An easily accessible list of all the objects

    private PlayerMovement player;
    /*//Enum to store possible properties of objects
    // 0 - None
    // 1 - Dangerous
    // 2 - Moveable
    // 3 - Moveable and Dangerous
    // 4 - Reflects
    // 5 - Reflects and Dangerous
    // 6 - Reflects and Moveable
    // 7 - Reflects, Dangerous, and Moveable
    // 8 - Pipe
    // 9 - Pipe and Dangerous
    // 10 - Pipe and Moveable
    // 11 - Pipe, dangerous, and moveable
    // 12 - Pipe and Reflects
    // 13 - Pipe, Reflects, and Dangerous
    // 14 - Pipe, Reflects, and Moveable
    // 15 - Pipe, Reflects, Dangerous, and Moveable
    // 16 - 16
    public enum ObjectProperties : short
    {
        None = 0,
        Dangerous = 1, //Kills the player
        Moveable = 2, //Can be moved with telekinesis
        Reflects = 4, //Reflects lasers
        Pipe = 8 //Connecting pipes puzzle - Van's idea
    }
    public int properties;
    private ObjectProperties objProperties;
    */
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerMovement.player;
        if (objects == null)
        {
            objects = new List<Object>();
        }
        objects.Add(this);
        //objProperties = (ObjectProperties)properties;
    }

    // Update is called once per frame
    void Update() //Probably need stuff here for pipes
    {
        
    }
}
