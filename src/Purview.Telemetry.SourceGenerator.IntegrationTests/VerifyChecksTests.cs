[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1050:Declare types in namespaces")]
public sealed class VerifyChecksTests
{
	[Fact]
	public Task Run() =>
		VerifyChecks.Run();
}
