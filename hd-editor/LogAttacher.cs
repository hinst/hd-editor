using NLog;

namespace hd_editor
{
	
	static class LogAttacher
	{
	
		public static Logger getLogger(this object o)
		{
			return LogManager.GetLogger(o.GetType().Name);
		}
	
	}
	
}
