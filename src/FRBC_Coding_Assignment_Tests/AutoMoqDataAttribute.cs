using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using System.Diagnostics.CodeAnalysis;

namespace FRBC_Coding_Assignment_Tests
{
    [ExcludeFromCodeCoverage]
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : this(new Fixture()) { }

        public AutoMoqDataAttribute(IFixture fixture) : base(() => fixture.Customize(new AutoMoqCustomization())) { }
    }
}
