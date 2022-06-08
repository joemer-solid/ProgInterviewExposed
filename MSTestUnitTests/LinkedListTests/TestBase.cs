using MSTestUnitTests.LinkedListTests.Setup;

namespace MSTestUnitTests.LinkedListTests
{
    public abstract class TestBase
    {
        private static LinkedListsTestsSetup _setup;

        protected static LinkedListsTestsSetup Setup
        {
            get
            {
                if (_setup == null)
                {
                    _setup = new LinkedListsTestsSetup();
                }

                return _setup;
            }

        }
    }               
}
