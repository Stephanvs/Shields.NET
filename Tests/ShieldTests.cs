using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shields;

namespace Tests
{
    [TestClass]
    public class ShieldTests
    {
        [TestMethod]
        public void CanCreateSimpleShield()
        {
            var s = new Shield("hello", "world");

            s.Subject.Should().Be("hello");
            s.Value.Should().Be("world");
            s.Color.Should().Be(ColorScheme.BrightGreen);
            s.Format.Should().Be("svg");
            s.ToString().Should().Be("hello-world-brightgreen.svg");
        }

        [TestMethod]
        public void CanCreateShieldFromString()
        {
            var s = Shield.FromPattern("hello-world-yellow.svg");

            s.Subject.Should().Be("hello");
            s.Value.Should().Be("world");
            s.Color.Should().Be(ColorScheme.Yellow);
            s.Format.Should().Be("svg");
            s.ToString().Should().Be("hello-world-yellow.svg");
        }

        [TestMethod]
        public void CanCreateShieldFromStringWithHexColor()
        {
            var s = Shield.FromPattern("hello-world-ff69b4.svg");

            s.Subject.Should().Be("hello");
            s.Value.Should().Be("world");
            s.Format.Should().Be("svg");
            s.Color.Should().Be("#ff69b4");
            s.ToString().Should().Be("hello-world-ff69b4.svg");
        }
    }
}
