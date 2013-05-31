//Copyright (c) CodeSharp.  All rights reserved.

using System;
using System.Collections;
using System.Threading;

namespace CodeSharp.EventSourcing
{
    /// <summary>
    /// �ṩ����ֵ��������Ϊ��ʵ�÷���
    /// </summary>
    public static class LockUtility
    {
        private class LockObject
        {
            public int Counter { get; set; }
        }

        /// <summary>
        /// �������, �������ü�������0�������󶼻��ڳ��л�������
        /// </summary>
        private static readonly Hashtable _lockPool = new Hashtable();

        /// <summary>
        /// �÷������Ը���ĳ��ֵ�����ֵ����ס��Ӧ����Ϊ��
        /// �÷�����ϵͳlock��������������סĳ��ָ����key��ֻҪkey��ֵ��ͬ����ôaction��ִ�оͲ���������
        /// <remarks>
        /// ��Ƹ÷�����Ϊ���ֲ�.net��ܵ�lock�����ľ����ԡ�.net��ܵ�lock����ֻ����������ͬ�Ķ���
        /// ���Ǻܶ�ʱ������ϣ����סĳ��ֵ����ֻҪ��ֵ�����ֵ��ͬ����action�Ͳ���������
        /// </remarks>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        public static void Lock(object key, System.Action action)
        {
            var lockObj = GetLockObject(key);
            try
            {
                lock (lockObj)
                {
                    action();
                }
            }
            finally
            {
                ReleaseLockObject(key, lockObj);
            }
        }

        /// <summary>
        /// �ͷ�������, ���������ü���Ϊ0ʱ, ����������Ƴ�
        /// </summary>
        /// <param name="key"></param>
        /// <param name="lockObj"></param>
        private static void ReleaseLockObject(object key, LockObject lockObj)
        {
            lockObj.Counter--;
            lock (_lockPool)
            {
                //Console.WriteLine(string.Format("I am thread {0}:lock counter is {1}", Thread.CurrentThread.Name, lockObj.Counter));
                if (lockObj.Counter == 0)
                {
                    _lockPool.Remove(key);
                }
            }
        }
        /// <summary>
        /// ����������л�ȡ������, ��������������ü�����1.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static LockObject GetLockObject(object key)
        {
            lock (_lockPool)
            {
                var lockObj = _lockPool[key] as LockObject;
                if (lockObj == null)
                {
                    lockObj = new LockObject();
                    _lockPool[key] = lockObj;
                }
                lockObj.Counter++;
                return lockObj;
            }
        }
    }
}