using System;

namespace LoggerMetrics.Exceptions;

public sealed class NotFoundException : Exception
{
	public NotFoundException(string message) : base(message) { }
}