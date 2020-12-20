using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    public interface IOperator
    {
        string OperatorName { get; }
        void Execute();
    }

    [System.Serializable]
    public class Operator:IOperator
    {
        [SerializeField] string m_OperatorName;
        public string OperatorName => m_OperatorName;

        public void Execute()
        {
            Debug.Log(m_OperatorName);
        }
    }
}
