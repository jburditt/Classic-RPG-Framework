using System;

namespace DataStore
{
    public interface IModified
    {
        DateTime CreatedOn { get; }
        DateTime LastModified { get; }
    }
}