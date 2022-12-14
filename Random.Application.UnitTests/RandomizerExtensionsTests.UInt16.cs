// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Application.Extensions;
using Depra.Random.Application.System.Collections;
using Depra.Random.Application.UnitTests.Helpers;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class UInt16
    {
        private INumberRandomizer<int> _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new PseudoRandomizers().GetNumberRandomizer<int>();

        [Test]
        public void WhenGettingNextUInt16_AndRangeIsDefault_ThenRandomNumbersAreNotTheSame(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomValues = new ushort[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomValues[i] = randomizer.NextUShort();
            }

            ConsoleHelper.PrintCollection(randomValues);

            // Assert.
            randomValues.Any(value => value != randomValues.First()).Should().BeTrue();
        }

        [Test]
        public void WhenGettingNextUInt16_AndInRangeWithMax_ThenRandomNumbersAreInGivenRange(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            const ushort minValue = 0;
            const ushort maxValue = ushort.MaxValue;
            var randomizer = _randomizer;
            var randomNumbers = new ushort[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextUShort(maxValue);
            }

            ConsoleHelper.PrintRandomizeResultForCollection(randomNumbers, minValue, maxValue);

            // Assert.
            randomNumbers.Should().AllSatisfy(randomNumber => randomNumber.Should().BeInRange(minValue, maxValue));
        }

        [Test]
        public void WhenGettingNextUInt16_AndInRangeWithMinAndMax_ThenRandomNumbersAreInGivenRange(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            const ushort minValue = ushort.MinValue;
            const ushort maxValue = ushort.MaxValue;
            var randomizer = _randomizer;
            var randomNumbers = new ushort[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextUShort(minValue, maxValue);
            }

            ConsoleHelper.PrintRandomizeResultForCollection(randomNumbers, minValue, maxValue);

            // Assert.
            randomNumbers.Should().AllSatisfy(randomNumber => randomNumber.Should().BeInRange(minValue, maxValue));
        }
    }
}