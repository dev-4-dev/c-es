//Copyright (c) CodeSharp.  All rights reserved.

namespace CodeSharp.EventSourcing
{
    /// <summary>
    /// �����������ڹ������ӿڶ���
    /// </summary>
    public interface ILifetimeManager<out T> where T : class, ILifetimeObject
    {
        /// <summary>
        /// �洢ĳ������
        /// </summary>
        void Store(string key, ILifetimeObject obj);
        /// <summary>
        /// �Ƴ�ĳ������
        /// </summary>
        void Remove(ILifetimeObject obj);
        /// <summary>
        /// ����key����һ�����õĶ���
        /// </summary>
        T Find(string key);
    }
}
