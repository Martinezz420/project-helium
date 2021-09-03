﻿namespace Helium.Commons.Logging;

/// <summary>
/// Part of the Helium Toolchain API. Indicates the severity of the log entry as well as various formatting data.
/// </summary>
public enum LogLevel
{
	Debug,
	Trace,
	Info,
	Warning,
	Error,
	Critical,
	Fatal
}
