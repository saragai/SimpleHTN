using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    // �����
    public interface IOperator
    {
        string OperatorName { get; }
        IEnumerator Execute(IOperatable operatable);
    }

    // ����Ώ�
    public interface IOperatable
    {
        Transform Transform { get; }
    }

    /// <summary>
    /// �^�X�N���s������̐ݒ�N���X
    /// </summary>
    [CreateAssetMenu(fileName ="operator.asset", menuName = "Operator", order = 1)]
    public class Operator: ScriptableObject, IOperator
    {
        [SerializeField] string m_OperatorName;
        public string OperatorName => m_OperatorName;

        /// <summary>
        /// ��������s
        /// </summary>
        /// <param name="operatable">���삳������</param>
        /// <returns></returns>
        public virtual IEnumerator Execute(IOperatable operatable)
        {
            Debug.Log(m_OperatorName);
            yield return null;
        }
    }
}
