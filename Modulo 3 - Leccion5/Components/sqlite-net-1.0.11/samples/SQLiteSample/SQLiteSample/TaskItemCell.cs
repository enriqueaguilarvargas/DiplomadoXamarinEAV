using Xamarin.Forms;

namespace SQLiteSample
{
	public class TaskItemCell : ViewCell
	{
		public TaskItemCell ()
		{
			var label = new Label {
				YAlign = TextAlignment.Center
			};
			var stripe = new BoxView {
				Color = Color.Red
			};
			label.SetBinding (Label.TextProperty, new Binding ("Name"));
			stripe.SetBinding (BoxView.IsVisibleProperty, new Binding ("Completed"));

			var layout = new RelativeLayout {
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.StartAndExpand
			};
			layout.Children.Add (
				label, 
				Constraint.RelativeToParent (p => 20),
				Constraint.RelativeToParent (p => 0),
				Constraint.RelativeToParent (p => p.Width - 40),
				Constraint.RelativeToParent (p => p.Height));
			layout.Children.Add (
				stripe, 
				Constraint.RelativeToParent (p => 10),
				Constraint.RelativeToParent (p => (p.Height / 2) - 1),
				Constraint.RelativeToParent (p => p.Width - 20),
				Constraint.RelativeToParent (p => 2));
			View = layout;
		}
	}
}
