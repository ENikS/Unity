using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
using Unity.Resolution;
#endif

namespace Registrations
{
    public partial class RegisterFactory
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Ignore]
        public void Null_Null_Null()
        {
            // Act
            //Container.RegisterFactory(null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Null_Factory()
        {
            // Act
            Container.RegisterFactory(null, null, (c,t,n)=> null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Ignore]
        public void Type_Null_Null()
        {
            // Act
            //Container.RegisterFactory(typeof(object), null, null, null);
        }

        [TestMethod]
        public void DefaultLifetime()
        {
            // Arrange
            var value = new object();
            Container.RegisterFactory(typeof(object), null, (c, t, n) => value);

            // Act
            var registration = Container.Registrations.First(r => typeof(object) == r.RegisteredType);

            // Validate
            Assert.IsInstanceOfType(registration.LifetimeManager, typeof(TransientLifetimeManager));
        }

        [TestMethod]
        public void CanSetLifetime()
        {
            // Arrange
            Container.RegisterFactory(typeof(object), null, (c, t, n) => null, new ContainerControlledLifetimeManager());

            // Act
            var registration = Container.Registrations.First(r => typeof(object) == r.RegisteredType);

            // Validate
            Assert.IsInstanceOfType(registration.LifetimeManager, typeof(ContainerControlledLifetimeManager));
        }

        [TestMethod]
        public void Type_Null_Factory()
        {
            // Arrange
            var value = new object();
            Container.RegisterFactory(typeof(object), null, (c, t, n) => value);

            // Act
            var instance = Container.Resolve<object>();

            // Validate
            Assert.AreSame(value, instance);
        }

        [TestMethod]
        public void Type_Name_Factory()
        {
            // Arrange
            var value = new object();
            Container.RegisterFactory(typeof(object), Name, (c, t, n) => value);

            // Act
            var instance = Container.Resolve<object>(Name);

            // Validate
            Assert.AreSame(value, instance);
        }
    }
}
