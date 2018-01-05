using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6.R07
{
    class CSharp6
    {
        public static async Task<string> MakeRequest()
        {
            var client = new System.Net.Http.HttpClient();
            var streamTask = client.GetStringAsync("https://localHost:10000");
            try
            {
                var responseText = await streamTask;
                return responseText;
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
            {
                return "Site Moved";
            }
        }

        public void MethodThatFailsSometimes()
        {
            try
            {
                PerformFailingOperation();
            }
            catch (Exception e) when (e.LogException())
            {
                // This is never reached!
            }
        }

        private void PerformFailingOperation()
        {
            throw new NotImplementedException();
        }

        public void MethodThatFailsButHasRecoveryPath()
        {
            try
            {
                PerformFailingOperation();
            }
            catch (Exception e) when (e.LogException())
            {
                // This is never reached!
            }
            catch (RecoverableException ex)
            {
                Console.WriteLine(ex.ToString());
                // This can still catch the more specific
                // exception because the exception filter
                // above always returns false.
                // Perform recovery here 
            }
        }

        public static async Task<string> MakeRequestWithNotModifiedSupport()
        {
            var client = new System.Net.Http.HttpClient();
            var streamTask = client.GetStringAsync("https://localHost:10000");
            try
            {
                var responseText = await streamTask;
                return responseText;
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
            {
                return "Site Moved";
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("304"))
            {
                return "Use the Cache";
            }
        }

        public void MethodThatFailsWhenDebuggerIsNotAttached()
        {
            try
            {
                PerformFailingOperation();
            }
            catch (Exception e) when (e.LogException())
            {
                // This is never reached!
            }
            catch (RecoverableException ex) when (!System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine(ex.ToString());
                // Only catch exceptions when a debugger is not attached.
                // Otherwise, this should stop in the debugger. 
            }
        }
    }

    class RecoverableException : Exception
    {

    }

    static class ExceptionExtensions
    {
        public static bool LogException(this Exception e)
        {
            Console.Error.WriteLine($"Exceptions happen: {e}");
            return false;
        }
    }
}
