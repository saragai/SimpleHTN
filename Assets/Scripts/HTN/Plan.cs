using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    public class Plan
    {
        Queue<IOperator> m_Operators;

        public IEnumerable<IOperator> Operators => m_Operators;

        public Plan()
        {
            m_Operators = new Queue<IOperator>();
        }

        public Plan(Plan other)
        {
            m_Operators = new Queue<IOperator>(other.m_Operators);
        }

        public void Clear()
        {
            m_Operators.Clear();
        }

        public void Enqueue(IOperator @operator)
        {
            m_Operators.Enqueue(@operator);
        }
    }
}
