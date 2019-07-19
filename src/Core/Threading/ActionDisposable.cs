namespace DotNetConcept.Toolkit.Threading
{
    using System;
    using JetBrains.Annotations;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ActionDisposable : IDisposable
    {
        /// <summary>
        /// The action
        /// </summary>
        private readonly Action action;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionDisposable"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public ActionDisposable([NotNull]Action action)
        {
            this.action = action;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.action();
        }
    }
}