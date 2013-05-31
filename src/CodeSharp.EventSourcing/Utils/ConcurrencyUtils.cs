//Copyright (c) CodeSharp.  All rights reserved.

using System;
using System.Collections;
using System.Threading;

namespace CodeSharp.EventSourcing
{
    /// <summary>
    /// �ṩ������д���Ƶ�ʵ�÷���
    /// </summary>
    public static class ConcurrencyUtils
    {
        /// <summary>
        /// �÷���ȷ������ʱ�򲻻�����д
        /// </summary>
        public static void AtomRead(System.Action action)
        {
            new ReaderWriterLockSlim().AtomRead(action);
        }
        /// <summary>
        /// �÷���ȷ������ʱ�򲻻�����д
        /// </summary>
        public static void AtomRead(this ReaderWriterLockSlim readerWriterLockSlim, System.Action action)
        {
            if (readerWriterLockSlim == null)
            {
                throw new ArgumentNullException("readerWriterLockSlim");
            }
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            readerWriterLockSlim.EnterReadLock();

            try
            {
                action();
            }
            finally
            {
                readerWriterLockSlim.ExitReadLock();
            }
        }
        /// <summary>
        /// �÷���ȷ������ʱ�򲻻�����д
        /// </summary>
        public static T AtomRead<T>(Func<T> function)
        {
            return new ReaderWriterLockSlim().AtomRead<T>(function);
        }
        /// <summary>
        /// �÷���ȷ������ʱ�򲻻�����д
        /// </summary>
        public static T AtomRead<T>(this ReaderWriterLockSlim readerWriterLockSlim, Func<T> function)
        {
            if (readerWriterLockSlim == null)
            {
                throw new ArgumentNullException("readerWriterLockSlim");
            }
            if (function == null)
            {
                throw new ArgumentNullException("function");
            }

            readerWriterLockSlim.EnterReadLock();

            try
            {
                return function();
            }
            finally
            {
                readerWriterLockSlim.ExitReadLock();
            }
        }
        /// <summary>
        /// �÷���ȷ��������ʱ��ֻ��һ����д
        /// </summary>
        public static void AtomWrite(System.Action action)
        {
            new ReaderWriterLockSlim().AtomWrite(action);
        }
        /// <summary>
        /// �÷���ȷ��������ʱ��ֻ��һ����д
        /// </summary>
        public static void AtomWrite(this ReaderWriterLockSlim readerWriterLockSlim, System.Action action)
        {
            if (readerWriterLockSlim == null)
            {
                throw new ArgumentNullException("readerWriterLockSlim");
            }
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            readerWriterLockSlim.EnterWriteLock();

            try
            {
                action();
            }
            finally
            {
                readerWriterLockSlim.ExitWriteLock();
            }
        }
        /// <summary>
        /// �÷���ȷ��������ʱ��ֻ��һ����д
        /// </summary>
        public static T AtomWrite<T>(Func<T> function)
        {
            return new ReaderWriterLockSlim().AtomWrite<T>(function);
        }
        /// <summary>
        /// �÷���ȷ��������ʱ��ֻ��һ����д
        /// </summary>
        public static T AtomWrite<T>(this ReaderWriterLockSlim readerWriterLockSlim, Func<T> function)
        {
            if (readerWriterLockSlim == null)
            {
                throw new ArgumentNullException("readerWriterLockSlim");
            }
            if (function == null)
            {
                throw new ArgumentNullException("function");
            }

            readerWriterLockSlim.EnterWriteLock();

            try
            {
                return function();
            }
            finally
            {
                readerWriterLockSlim.ExitWriteLock();
            }
        }
    }
}