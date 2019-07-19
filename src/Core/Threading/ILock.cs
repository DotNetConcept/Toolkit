namespace DotNetConcept.Toolkit.Threading
{
    using System;

    /// <summary>
    /// The Lock interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface ILock<T>
    {
        /// <summary>
        /// Enters the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IDisposable Enter(T id);
    }
}