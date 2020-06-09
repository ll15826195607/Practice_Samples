using System;
using System.Diagnostics;

namespace ProxyDemo
{
	public class UserControllerProxy : IProxyInvocationHandler
	{
        private Object obj = null;
        private UserControllerProxy(Object obj)
        {
            this.obj = obj;
        }

        ///<summary>
        /// 工厂方法创建一个新的代理实例
        ///</summary>
        public static Object CreateInstance(Object obj) 
        {
            return ProxyFactory.GetInstance().Create(new UserControllerProxy(obj), obj.GetType());
        }

        ///<summary>
        /// IProxyInvocationHandler method that gets called from within the proxy
        /// instance. 
        ///</summary>
        ///<param name="proxy">代理实例</param>
        ///<param name="method">方法实例</param>
        public Object Invoke(Object proxy, System.Reflection.MethodInfo method, Object[] parameters) 
        {
            Console.WriteLine(Environment.NewLine);
            Object retVal = null;
            string userRole = "role";

            Console.WriteLine("调用前需要做的事情，也可以不做...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // 判断是否有调用权限
            if (SecurityManager.IsMethodInRole(userRole, method.Name)) 
            {
                retVal = method.Invoke(obj, parameters);
            }
            else
            {
                throw new Exception( "Invalid permission to invoke " + method.Name ); 
            }
            stopwatch.Stop();
            Console.WriteLine(String.Format("响应时间: {0} ms", stopwatch.ElapsedMilliseconds));
            Console.WriteLine("调用后需要做的事情，也可以不做...");
            return retVal;
        }
    }
}
