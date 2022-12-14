// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.ServiceBuilder
{
    public static class RandomServiceBuilderExtensions
    {
        public static IRandomServiceBuilder With<T>(this IRandomServiceBuilder builder,
            ITypedRandomizer<T> randomizer) => builder.With(typeof(T), randomizer);

        public static IRandomServiceBuilder With<T>(this IRandomServiceBuilder builder,
            IArrayRandomizer<T> randomizer) => builder.With(typeof(T), randomizer);

        public static IRandomServiceBuilder With(this IRandomServiceBuilder builder,
            IRandomizerCollection fromCollection)
        {
            var randomizers = fromCollection.GetAllRandomizers();
            foreach (var randomizer in randomizers)
            {
                Console.WriteLine(randomizer.ValueType);
                builder.With(randomizer.ValueType, randomizer);
            }

            return builder;
        }

        public static IRandomServiceBuilder With<T>(this IRandomServiceBuilder builder,
            IRandomizerCollection fromCollection) => With(builder, typeof(T), fromCollection);

        public static IRandomServiceBuilder With(this IRandomServiceBuilder builder, Type valueType,
            IRandomizerCollection fromCollection) => builder.With(valueType, fromCollection.GetRandomizer(valueType));
    }
}