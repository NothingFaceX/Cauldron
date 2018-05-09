﻿using System.Collections.Generic;

namespace Cauldron.Activator
{
    internal class FactoryTypeInfoComparer : IEqualityComparer<IFactoryTypeInfo>
    {
        public bool Equals(IFactoryTypeInfo x, IFactoryTypeInfo y)
        {
            if (x == null || y == null)
                return false;

            return x.ContractName == y.ContractName && x.Type.FullName == y.Type.FullName;
        }

        public int GetHashCode(IFactoryTypeInfo obj)
        {
            if (obj == null)
                return 0;

            return obj.ContractName.GetHashCode() ^ obj.Type.FullName.GetHashCode();
        }
    }
}