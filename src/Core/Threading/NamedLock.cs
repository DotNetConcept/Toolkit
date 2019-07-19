namespace DotNetConcept.Toolkit.Threading
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class NamedLock<T> : ILock<T>
    {
        private readonly object globalLock = new object();

        private readonly Dictionary<T, Tuple<object, int>> locks = new Dictionary<T, Tuple<object, int>>();

        public IDisposable Enter(T id)
        {
            object lockHandle;

            lock (this.globalLock)
            {
                if (!this.locks.ContainsKey(id))
                {
                    this.locks[id] = Tuple.Create(new object(), 1);
                }
                else
                {
                    var lockCount = this.locks[id];
                    this.locks[id] = Tuple.Create(lockCount.Item1, lockCount.Item2 + 1);
                }

                lockHandle = this.locks[id].Item1;
            }

            // Any exceptions dealing with the dictionary up to this point are fine as the lock has not been taken
            // we need to be more careful after this point
            var lockTaken = false;
            try
            {
                // Monitor.Enter can throw an exception AND take the lock
                // we need to catch this and exit the lock, making sure we rethrow the exception as well
                Monitor.Enter(lockHandle, ref lockTaken);
            }
            catch
            {
                if (lockTaken)
                {
                    Monitor.Exit(lockHandle);
                    throw;
                }
            }

            try
            {
                // don’t think this call should ever fail but lets make sure we release the lock if it has
                return new ActionDisposable(() => this.Exit(id, lockHandle));
            }
            catch
            {
                Monitor.Exit(lockHandle);
                throw;
            }
        }

        private void Exit(T id, object lockHandle)
        {
            // We need to be careful here that we actually release the lock
            // since the dictionary might blow up, we actually pass the lockHandle to this method as well
            // any exception occuring before we have managed to update the dictionary
            // is caught and the lock released anyway.
            // The worst case scenario is we will end up with the dictionary saying there are outstanding locks for a certain key
            // Whereas there are actually none
            // This won’t cause a deadlock, but may cause a minor memory leak
            lock (this.globalLock)
            {
                Tuple<object, int> lockCount = default;
                try
                {
                    lockCount = this.locks[id];
                    if (lockCount.Item2 == 1)
                    {
                        this.locks.Remove(id);
                    }
                    else
                    {
                        this.locks[id] = Tuple.Create(lockCount.Item1, lockCount.Item2 - 1);
                    }
                }
                catch
                {
                    Monitor.Exit(lockHandle);
                    throw;
                }

                Monitor.Exit(lockCount.Item1);
            }
        }
    }
}