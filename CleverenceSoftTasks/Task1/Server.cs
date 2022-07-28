using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverenceSoftTasks.Task1
{
    public static class Server
    {
        private static int _count;

        private static ReaderWriterLockSlim _cacheLock = new ReaderWriterLockSlim();

        public static int GetCount()
        {
            _cacheLock.EnterReadLock();
            try
            {
                Console.WriteLine("Read count. count = {0}", _count);
                return _count;
            }
            finally
            {
                _cacheLock.ExitReadLock();
            }
        }

        public static void AddToCount(int value)
        {
            _cacheLock.EnterWriteLock();
            try
            {
                _count += value;
                Console.WriteLine("Add to Count. count = {0}", _count);
            }
            finally
            {
                _cacheLock.ExitWriteLock();
            }
        }
    }
}
