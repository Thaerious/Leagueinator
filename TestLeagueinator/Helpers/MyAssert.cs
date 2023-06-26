using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeagueinator.Helpers {
    public static class MyAssert {
        public static void Throws<T>(Action func) where T : Exception {
            var exceptionThrown = false;
            try {
                func.Invoke();
            }
            catch (T) {
                exceptionThrown = true;
            }

            if (!exceptionThrown) {
                throw new AssertFailedException(
                    String.Format("An exception of type {0} was expected, but not thrown", typeof(T))
                );
            }
        }
    }
}

// [1] https://stackoverflow.com/questions/933613/how-do-i-use-assert-to-verify-that-an-exception-has-been-thrown-with-mstest
