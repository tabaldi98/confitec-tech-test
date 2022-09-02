using Bogus;
using Moq;
using Moq.Language.Flow;
using NUnit.Framework;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace Confitec.Technical.Test.Tests
{
    public static class CacheMockExtensions
    {
        private static readonly ConcurrentDictionary<string, ConcurrentBag<Mock>> _cachedMocks = new ConcurrentDictionary<string, ConcurrentBag<Mock>>();

        public static ISetup<T, Task<TResult>> SetupVerifiable<T, TResult>(this Mock<T> mock, Expression<Func<T, Task<TResult>>> setup) where T : class
        {
            AddMockToCache(mock);

            return mock.Setup(setup);
        }

        private static void AddMockToCache<T>(Mock<T> mock) where T : class
        {
            var testName = TestContext.CurrentContext.Test.Name;

            if (!_cachedMocks.ContainsKey(testName))
            {
                _cachedMocks.TryAdd(testName, new ConcurrentBag<Mock>());
            }

            if (!_cachedMocks[testName].Any(p => p == mock))
            {
                _cachedMocks[testName].Add(mock);
            }
        }

        public static void VerifyAllCachedMocks()
        {
            var testName = TestContext.CurrentContext.Test.Name;

            try
            {
                foreach (var item in _cachedMocks.Where(p => p.Key.Equals(testName)).SelectMany(p => p.Value))
                {
                    item.VerifyAll();
                }
            }
            finally
            {
                _cachedMocks.TryRemove(testName, out var value);
            }
        }

    }
}

