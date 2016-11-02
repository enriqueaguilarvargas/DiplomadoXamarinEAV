using Xamarin.Forms;

using SQLite;

namespace SQLiteSample
{
	public class App : Application
	{
		private readonly SQLiteAsyncConnection db;

		public App (string dbPath)
		{
			// set up the database
			db = new SQLiteAsyncConnection (dbPath);
			db.CreateTableAsync<TaskItem> ().Wait ();

			// The root page of your application
			MainPage = new NavigationPage (new TasksPage (db));
		}
	}
}
