// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Application.Extensions;
using Depra.Random.Application.System.Collections;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Benchmarks.Extensions;

public class DoubleRandomizerExtensionsBenchmarks
{
    private ITypedRandomizer<double> _doubleRandomizer;

    [GlobalSetup]
    public void Setup() => _doubleRandomizer = new PseudoRandomizers().GetTypedRandomizer<double>();

    [Benchmark]
    public double NextDoubleInRange() => _doubleRandomizer.NextDouble(double.MinValue, double.MaxValue);
}