using System;
using Sirenix.OdinInspector;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public sealed class CharacterStat
    {
        public event Action<int> OnValueChanged;
        public event Action<string> OnValueChangedStr;

        [ShowInInspector, ReadOnly] public string Name { get; private set; }

        [ShowInInspector, ReadOnly] public int Value { get; private set; }

        public CharacterStat(string name, int value)
        {
            Name = name;
            Value = value;
        }

        [Button]
        public void ChangeValue(string name, int value)
        {
            Value = value;
            Name = name;
            OnValueChanged?.Invoke(value);
            OnValueChangedStr?.Invoke(MatToViewText());
        }

        public string MatToViewText()
        {
            return $"{Name}: {Value}";
        }
    }
}