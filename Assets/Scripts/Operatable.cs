using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTN;

/// <summary>
/// ���삳���Ώ�
/// </summary>
public class Operatable: MonoBehaviour, IOperatable
{
    Transform IOperatable.Transform => transform;
}
