using System;
using Baarne.Application.Interfaces;

namespace Baarne.Infrastructure.Services
{
    public class TestService : ITestService
    {
        public string GetStatus()
        {
            return "Dependency Injection Çalışıyor!!!";
        }
    }
}
