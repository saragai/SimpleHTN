using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HTN;

/// <summary>
/// WorldState�ێ���
/// </summary>
public class WorldStateHolder : MonoBehaviour
{
    [SerializeField] WorldState m_WorldState;

    public WorldState WorldState => m_WorldState;
}
