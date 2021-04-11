using System;

namespace Test.data
{
    public interface IDbFactory : IDisposable
    {
        TestContext Init();
    }
}