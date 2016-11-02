using SQLite;

namespace SQLiteSample
{
	public class TaskItem
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public string Name { get; set; }

		public bool Completed { get; set; }
	}
}