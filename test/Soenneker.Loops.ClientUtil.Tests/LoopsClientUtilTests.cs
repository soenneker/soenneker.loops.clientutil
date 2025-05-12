using Soenneker.Loops.ClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Loops.ClientUtil.Tests;

[Collection("Collection")]
public class LoopsClientUtilTests : FixturedUnitTest
{
    private readonly ILoopsClientUtil _util;

    public LoopsClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<ILoopsClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
