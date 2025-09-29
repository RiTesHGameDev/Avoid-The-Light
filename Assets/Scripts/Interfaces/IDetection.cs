using System;

public interface IDetection
{
	event Action OnPlayerDetected;
	void StartDetection();
	void StopDetection();
}
