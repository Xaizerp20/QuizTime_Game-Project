namespace QuizTime_Game;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnPlayClick(object sender, EventArgs e)
	{

        Navigation.PushAsync(new QuestionsPage()); //go to questions page on click button
		/*
        count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
		*/
	}
}


