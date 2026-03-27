using System;

namespace CodeBase.Runtime.Core.InputModule
{
    public interface IInputListener
    {
        event Action<DirectionType> Swiped;
    }
}