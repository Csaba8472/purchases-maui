namespace RevenuecatTest;

using maui_purchases_lib;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

        Purchases.Instance.Setup("appl_jAifDBxaCGxqhemGewxBPzGDbpf", "appc5a56e12b2", true, null, () => { }, (code, msg) => { });
        Purchases.Instance.GetOfferings((Offerings offerings) => { }, (code, msg) => { });
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

