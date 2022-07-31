using System;

namespace Modules.Mvvm
{
    public interface IReactiveProperty<out T>
    {
        T Value { get; }
        event Action ValueChanged;
    }
}