using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HTN
{
    [System.Serializable]
    public class Condition
    {
        [SerializeField] WorldState.TYPE m_Type;
        [SerializeField] bool m_Value;

        /// <summary>
        /// 状態を指定して条件を満たすか判断する
        /// </summary>
        /// <param name="state">状態</param>
        /// <returns>条件を満たすか</returns>
        public bool Match(WorldState state)
        {
            return state.Get(m_Type) == m_Value;
        }
    }
}
