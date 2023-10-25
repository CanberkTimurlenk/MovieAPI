using Castle.DynamicProxy;
using Serilog;
using Services.Utilities.Interceptors;

namespace Services.Aspects.Logging
{
    public class LogAspect : MethodInterception
    {
        protected override void OnException(IInvocation invocation, Exception ex)
        {
            Log.Error("An exception was thrown : {@Message} , {@Exception}", ex.Message, ex);

            Log.CloseAndFlush();
        }
    }
}
