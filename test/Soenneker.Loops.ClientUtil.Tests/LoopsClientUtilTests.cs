using Soenneker.Loops.ClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Loops.ClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class LoopsClientUtilTests : HostedUnitTest
{
    private readonly ILoopsClientUtil _util;

    public LoopsClientUtilTests(Host host) : base(host)
    {
        _util = Resolve<ILoopsClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
