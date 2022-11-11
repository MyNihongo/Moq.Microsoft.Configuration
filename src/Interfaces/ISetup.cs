namespace Moq;

public interface ISetup<in T>
{
	void Returns(T param);

	internal void ReturnsEmpty();
}
