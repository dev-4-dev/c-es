//Copyright (c) CodeSharp.  All rights reserved.

using System.Collections;

namespace CodeSharp.EventSourcing
{
    /// <summary>
    /// ��ʾһ����ILifetimeManager����Ķ���
    /// </summary>
    public interface ILifetimeObject
    {
        /// <summary>
        /// ��ʾʵ�ʴ�ŵ�ǰ�����һ��Stack����
        /// </summary>
        Stack OwnerStack { get; set; }
    }
}
