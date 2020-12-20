using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    /// <summary>
    /// ���E�̏��
    /// </summary>
    [System.Serializable]
    public class WorldState
    {
        /// <summary>
        /// ��Ԃ̎��
        /// </summary>
        public enum TYPE
        {
            IsHungry,
            HaveMoney,
            HaveMeal,

            MaxCount,
        }
        public static int NumStates => (int)TYPE.MaxCount;

        [SerializeField]
        private bool[] m_States;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public WorldState()
        {
            m_States = new bool[(int)TYPE.MaxCount];
        }

        /// <summary>
        /// ��ނƒl���w�肵�ď�Ԃ�ݒ�
        /// </summary>
        /// <param name="type">���</param>
        /// <param name="value">�l</param>
        public void Set(TYPE type, bool value)
        {
            m_States[(int)type] = value;
        }

        /// <summary>
        /// ��ނ��w�肵�ď�Ԃ̒l���擾
        /// </summary>
        /// <param name="type">���</param>
        /// <returns>�l</returns>
        public bool Get(TYPE type)
        {
            return m_States[(int)type];
        }

        /// <summary>
        /// ���g�𕡐�����
        /// </summary>
        /// <returns>���g�̕���</returns>
        public WorldState CreateCopy()
        {
            var copy = new WorldState();
            for (int i = 0; i < NumStates; i++)
            {
                copy.m_States[i] = m_States[i];
            }
            return copy;
        }

        public override string ToString()
        {
            string text = "";
            for (int i = 0; i < NumStates; i++)
            {
                text += $"{(TYPE)i}: {m_States[i]}\n";
            }
            return text;
        }

#if UNITY_EDITOR
        public static string StatesName => nameof(m_States);
#endif 
    }
}

#if UNITY_EDITOR
namespace HTN.Editor
{
    using UnityEditor;

    /// <summary>
    /// WorldState�̃G�f�B�^�g��
    /// </summary>
    [CustomPropertyDrawer(typeof(WorldState))]
    public class WorldStateDrawer : PropertyDrawer
    {
        static float LineHeight => EditorGUIUtility.singleLineHeight;
        static float Spacing => EditorGUIUtility.standardVerticalSpacing;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // �����I�����Ă���Ƃ��͉������Ȃ�
            if (property.hasMultipleDifferentValues)
                return;

            position.height = LineHeight;
            EditorGUI.LabelField(position, label);
            position.y += LineHeight + Spacing;

            EditorGUI.indentLevel++;
            {
                DrawContent();
            }
            EditorGUI.indentLevel--;

            return;

            // WorldState�̓��e��`��
            void DrawContent()
            {
                var statesProperty = property.FindPropertyRelative(WorldState.StatesName);

                for (int i = 0; i < WorldState.NumStates; i++)
                {
                    var stateProperty = statesProperty.GetArrayElementAtIndex(i);
                    var stateLabel = ((WorldState.TYPE)i).ToString();

                    stateProperty.boolValue = EditorGUI.Toggle(position, stateLabel, stateProperty.boolValue);

                    position.y += LineHeight + Spacing;
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            //�����I�����Ă���Ƃ��͂Ȃɂ����Ȃ�
            if (property.hasMultipleDifferentValues)
                return 0f;

            var numState = (int)WorldState.TYPE.MaxCount + 1;
            return (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * numState;
        }
    }
}
#endif 


