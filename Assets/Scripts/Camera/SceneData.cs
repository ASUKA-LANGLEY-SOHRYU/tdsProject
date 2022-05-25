using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    public Transform player;

    private void Awake()
    {
        DataManager.player = player;
    }
}
