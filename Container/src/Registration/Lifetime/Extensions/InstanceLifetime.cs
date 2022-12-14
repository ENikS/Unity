using Unity.Lifetime;

namespace Unity
{
    public static class InstanceLifetime
    {
        /// <summary>
        /// This lifetime stores a weak reference to an instance and returns an instance while it is available.
        /// </summary>
        /// <remarks>
        /// <para>Container gets a hold of a weak reference to the object and as long as the object 
        /// still exists and has not been garbage collected the container will return the object when
        /// requested.</para>
        /// <para>If the object went out of scope and has been garbage collected the container will 
        /// return <see cref="LifetimeManager.NoValue"/>.</para>
        /// <para>This lifetime manager does not dispose an object when container is disposed</para>
        /// </remarks>
        /// <value>A new instance of a <see cref="ExternallyControlledLifetimeManager"/> lifetime manager.</value>
        public static IInstanceLifetimeManager External => new ExternallyControlledLifetimeManager();

        /// <summary>
        /// Unity returns the same instance each time the Resolve(...) method is called or when 
        /// the dependency mechanism injects the instance into other classes.
        /// </summary>
        /// <remarks>
        /// Per Container lifetime allows a registration of an existing or resolved object as 
        /// a scoped singleton in the container it was created or registered. In other words this 
        /// instance is unique within the container it war registered with. Child or parent 
        /// containers could have their own instances registered for the same contract.
        /// </remarks>
        /// <value>A new instance of a <see cref="ContainerControlledLifetimeManager"/> object.</value>
        public static IInstanceLifetimeManager PerContainer => new ContainerControlledLifetimeManager();
    }
}
