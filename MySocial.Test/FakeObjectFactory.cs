using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;

namespace MySocial.Test
{
    internal static class FakeObjectFactory
    {
        private static readonly Dictionary<Type, object> Container = new Dictionary<Type, object>();

        static FakeObjectFactory()
        {
            Container.Add(typeof(ISettings), FakeSettings.GetFake());
        }

        internal static T Get<T>()
        {
            var obj = Container[typeof (T)];

            return obj == null ? default(T) : (T) obj;
        }
    }
}
