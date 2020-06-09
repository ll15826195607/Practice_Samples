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
        /// ������������һ���µĴ���ʵ��
        ///</summary>
        public static Object CreateInstance(Object obj) 
        {
            return ProxyFactory.GetInstance().Create(new UserControllerProxy(obj), obj.GetType());
        }

        ///<summary>
        /// IProxyInvocationHandler method that gets called from within the proxy
        /// instance. 
        ///</summary>
        ///<param name="proxy">����ʵ��</param>
        ///<param name="method">����ʵ��</param>
        public Object Invoke(Object proxy, System.Reflection.MethodInfo method, Object[] parameters) 
        {
            Console.WriteLine(Environment.NewLine);
            Object retVal = null;
            string userRole = "role";

            Console.WriteLine("����ǰ��Ҫ�������飬Ҳ���Բ���...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // �ж��Ƿ��е���Ȩ��
            if (SecurityManager.IsMethodInRole(userRole, method.Name)) 
            {
                retVal = method.Invoke(obj, parameters);
            }
            else
            {
                throw new Exception( "Invalid permission to invoke " + method.Name ); 
            }
            stopwatch.Stop();
            Console.WriteLine(String.Format("��Ӧʱ��: {0} ms", stopwatch.ElapsedMilliseconds));
            Console.WriteLine("���ú���Ҫ�������飬Ҳ���Բ���...");
            return retVal;
        }
    }
}
