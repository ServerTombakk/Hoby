﻿namespace test.Results
{
	public interface IResult
	{
		bool Success { get; }
		string Message { get; }
	}
}
