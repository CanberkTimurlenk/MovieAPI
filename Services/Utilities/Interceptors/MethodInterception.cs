using Castle.DynamicProxy;

namespace Services.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception ex) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        public async override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;

            OnBefore(invocation);

            try
            {
                invocation.Proceed();
                await (Task)invocation.ReturnValue;
            }
            catch (Exception ex)
            {
                isSuccess = false;
                OnException(invocation, ex);
            }
            finally
            {
                if (isSuccess)
                    OnSuccess(invocation);
            }

            OnAfter(invocation);
        }
    }
}
