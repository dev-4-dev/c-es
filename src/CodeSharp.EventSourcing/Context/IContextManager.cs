//Copyright (c) CodeSharp.  All rights reserved.

namespace CodeSharp.EventSourcing
{
    public interface IContextManager
    {
        /// <summary>
        /// ����һ�����õ�Contextʵ��
        /// </summary>
        IContext GetContext();
    }
}
