﻿namespace test.Results
{
	public class ErrorDataResult<T> : DataResult<T>
	{
		public ErrorDataResult(T data, string message) : base(data, false, message)
		{
		}
		public ErrorDataResult(T data) : base(data, false)
		{
		}
		public ErrorDataResult(String message) : base(default, false, message)
		{

		}
		public ErrorDataResult() : base(default, false)
		{

		}
	}
}
