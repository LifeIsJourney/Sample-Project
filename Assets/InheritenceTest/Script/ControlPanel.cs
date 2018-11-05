using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour {
    public Transform[] creatures;
    public void Move(int creatureIndex)
    {
        creatures[creatureIndex].SendMessage("Move");
    }public void Jump(int creatureIndex)
    {
        creatures[creatureIndex].SendMessage("Jump");
    }public void Talk(int creatureIndex)
    {
        creatures[creatureIndex].SendMessage("Talk");
    }
}
