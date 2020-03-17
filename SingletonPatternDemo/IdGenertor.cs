using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonPatternDemo
{
    #region 饿汉式
    //public class IdGenertor
    //{
    //    private long id = 0;
    //    private readonly static IdGenertor instance = new IdGenertor();
    //    private IdGenertor() { }
    //    public static IdGenertor GetInstance()
    //    {
    //        return instance;
    //    }

    //    public long GetId()
    //    {
    //        return Interlocked.Increment(ref this.id);
    //    }
    //}
    #endregion

    #region 懒汉式
    //public class IdGenertor
    //{
    //    private long id = 0;
    //    private readonly static Object locker = new Object();
    //    private static IdGenertor instance;
    //    private IdGenertor() { }
    //    public static  IdGenertor GetInstance()
    //    {
    //        lock (locker)
    //        {
    //            if (instance == null)
    //            {
    //                instance = new IdGenertor();
    //            }
    //            return instance;
    //        }
    //    }

    //    public long GetId()
    //    {
    //        return Interlocked.Increment(ref this.id);
    //    }
    //}
    #endregion

    #region 双重检测
    //public class IdGenertor
    //{
    //    private long id = 0;
    //    private readonly static Object locker = new Object();
    //    private static IdGenertor instance;
    //    private IdGenertor() { }
    //    public static IdGenertor GetInstance()
    //    {
    //        if (instance == null)
    //        {
    //            lock (locker)
    //            {
    //                if (instance == null)
    //                {
    //                    instance = new IdGenertor();
    //                }
    //            }
    //        }
    //        return instance;
    //    }

    //    public long GetId()
    //    {
    //        return Interlocked.Increment(ref this.id);
    //    }
    //}
    #endregion

    #region 静态内部类
    public class IdGenertor
    {
        private long id = 0;
        private IdGenertor() { }
        private static class SingletonHolder
        {
            public readonly static IdGenertor instance = new IdGenertor();
        }
        public static IdGenertor GetInstance()
        {
            return SingletonHolder.instance;
        }

        public long GetId()
        {
            return Interlocked.Increment(ref this.id);
        }
    }
    #endregion
}
