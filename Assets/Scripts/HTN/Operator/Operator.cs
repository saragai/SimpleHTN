using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    // ����Ώ�
    public interface IOperatable
    {
        Transform Transform { get; }
    }

    // �����
    public interface IOperator
    {
        string OperatorName { get; }
        IEnumerator Execute(IOperatable operatable);
    }

    namespace Operator
    {
        /// <summary>
        /// �^�X�N���s������̐ݒ�N���X
        /// </summary>
        public abstract class Operator : ScriptableObject, IOperator
        {
            [SerializeField] string m_OperatorName;
            public string OperatorName => m_OperatorName;

            /// <summary>
            /// ��������s
            /// </summary>
            /// <param name="operatable">���삳������</param>
            /// <returns></returns>
            public abstract IEnumerator Execute(IOperatable operatable);
        }
    }
}
