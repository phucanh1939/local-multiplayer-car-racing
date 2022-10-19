// ReSharper disable UnassignedField.Global
// ReSharper disable UnusedMember.Global

using GG.Base;
using UnityEngine;
using UnityEngine.Events;

namespace GG.Events
{
    [CreateAssetMenu(fileName = "StringEvent", menuName = "Events/String Event Channel", order = 0)]
    public class StringEventChannelSO : DescriptionBaseSO
    {
        public UnityAction<string> onEventRaised;
        public void RaiseEvent(string str) => onEventRaised?.Invoke(str);
    }
}