namespace Test.data
{
    using System;

    public class DataAccessObject : IDisposable
    {
        private TestContext _context;

        public DataAccessObject()
        {
            _context = new TestContext();
        }

        protected TestContext Context
        {
            get { return _context; }
        }

        public bool CommitImmediately { get; set; }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}