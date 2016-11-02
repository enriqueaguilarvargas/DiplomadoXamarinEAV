using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Acr.UserDialogs;

using SQLite;

namespace SQLiteSample
{
	public class TasksPage : ContentPage
	{
		private readonly SQLiteAsyncConnection db;
		private readonly ListView listView;

		public TasksPage (SQLiteAsyncConnection connection)
		{
			db = connection;

			Title = "Tasks";

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					(listView = new ListView {
						ItemTemplate = new DataTemplate (() => {
							// edit button
							var editItem = new MenuItem {
								Text = "Edit",
								Command = new Command (async param => {
									var task = (TaskItem)param;
									await EditItem (task);
								})
							};
							editItem.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));

							// delete button
							var deleteItem = new MenuItem {
								Text = "Delete",
								IsDestructive = true,
								Command = new Command (async param => {
									var task = (TaskItem)param;
									await DeleteItem (task);
								})
							};
							deleteItem.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));

							// list item
							var cell = new TaskItemCell {
								ContextActions = {
									editItem,
									deleteItem
								}
							};
							return cell;
						}),
					})
				}
			};

			listView.ItemSelected += async (sender, e) => {
				if (e.SelectedItem != null) {
					var task = (TaskItem)e.SelectedItem;
					await CompleteItem (task);

					listView.SelectedItem = null;
				}
			};

			var addButton = new ToolbarItem {
				Text = "Add",
				Command = new Command (async () => {
					await EditItem (null);
				})
			};
			ToolbarItems.Add (addButton);
		}

		protected override async void OnAppearing ()
		{
			base.OnAppearing ();

			using (UserDialogs.Instance.Loading ("Loading tasks...")) {
				await RefreshList ();
			}
		}

		private async Task RefreshList ()
		{
			var results = db.Table<TaskItem> ()
				.OrderBy (t => t.Completed)
				.OrderBy (t => t.Name);
			var items = await results.ToListAsync ();
			listView.ItemsSource = new ObservableCollection<TaskItem> (items);
		}

		private async Task EditItem (TaskItem task)
		{
			if (task == null) {
				task = new TaskItem ();
			}

			// get a new name
			var result = await UserDialogs.Instance.PromptAsync (
				             "Enter the name of the task:",
				             "Task",
				             "Add", 
				             "Cancel", 
				             "Task name");

			if (result.Ok) {
				var name = result.Text.Trim ();
				if (string.IsNullOrEmpty (name)) {
					// there was no name provided
					await UserDialogs.Instance.AlertAsync (
						"The task must have a name.",
						"Task");
				} else {
					// start adding tasks
					task.Name = name;
					using (UserDialogs.Instance.Loading ("Saving task...")) {
						// update DB
						if (task.Id == 0) {
							await db.InsertAsync (task);
						} else {
							await db.UpdateAsync (task);
						}

						// update UI
						await RefreshList ();
					}
				}
			}
		}

		private async Task CompleteItem (TaskItem task)
		{
			task.Completed = !task.Completed;

			using (UserDialogs.Instance.Loading ("Saving task...")) {
				// update DB
				await db.UpdateAsync (task);

				// update UI
				await RefreshList ();
			}
		}

		private async Task DeleteItem (TaskItem task)
		{
			var confirmed = await UserDialogs.Instance.ConfirmAsync (
				                string.Format ("Are you sure you want to delete '{0}'?", task.Name), 
				                "Delete Task", 
				                "Yes", 
				                "No");
			if (confirmed) {
				using (UserDialogs.Instance.Loading ("Deleting task...")) {
					// update DB
					await db.DeleteAsync (task);

					// update UI
					var tasks = (ObservableCollection<TaskItem>)listView.ItemsSource;
					tasks.Remove (task);
				}
			}
		}
	}
}
