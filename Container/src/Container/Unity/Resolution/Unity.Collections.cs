using System;
using Unity.Container;
using Unity.Lifetime;
using Unity.Resolution;

namespace Unity
{
    public partial class UnityContainer
    {
        #region Array

        private static object? ResolveArray(ref Contract contract, ref PipelineContext context)
        {
            throw new NotImplementedException();
            //var context = new ResolveContext(this, in contract, overrides);
            //var resolver = _policies[contract.Type];

            //// Nothing found, requires build
            //if (null == resolver)
            //{
            //    resolver = (ref ResolveContext c) => c.Target;
            //    _policies[contract.Type] = resolver;
            //}

            //return resolver(ref context);
        }

        /// <summary>
        /// Resolve array
        /// </summary>
        /// <param name="contract"><see cref="Contract"/> the array factory will be stored at</param>
        /// <param name="overrides">Overrides to use during resolution</param>
        /// <exception cref="ResolutionFailedException">if anything goes wrong</exception>
        /// <returns>Requested array</returns>
        private object? ResolveArray(ref Contract contract, ResolverOverride[] overrides)
        {
            var request = new RequestInfo(overrides);
            // TODO: Replace with array manager
            var context = new PipelineContext(this, ref contract, new TransientLifetimeManager(), ref request);


            var resolver = _policies[contract.Type];

            // Nothing found, requires build
            if (null == resolver)
            {
                resolver = (ref PipelineContext c) => c.Target;
                _policies[contract.Type] = resolver;
            }

            return resolver(ref context);
        }

        #endregion
    }
}
