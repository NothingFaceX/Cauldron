﻿using System.ComponentModel;

namespace Cauldron.Interception.Cecilator
{
    public interface IAction
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();

        void Insert(InsertionPosition position);

        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();
    }
}