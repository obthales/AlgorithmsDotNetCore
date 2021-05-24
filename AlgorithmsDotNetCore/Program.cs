using System;
using System.Configuration;

namespace AlgorithmsDotNetCore {
	class Program {
		public static void Main(string[] args) {
			string startup_project_name = ConfigurationManager.AppSettings["StartUpProject"];
			var type = Type.GetType(startup_project_name);
			var instance = Activator.CreateInstance(type);
			type.GetMethod("Run").Invoke(instance, null);
		}
	}
}
