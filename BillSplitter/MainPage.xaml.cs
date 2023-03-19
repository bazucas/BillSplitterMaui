namespace BillSplitter;

public partial class MainPage : ContentPage
{
    private decimal _bill;
    private int _tip;
    private int _noPersons = 1;

    public MainPage()
    {
        InitializeComponent();
    }

    private void txtBill_Completed(object sender, EventArgs e)
    {
        _bill = decimal.Parse(txtBill.Text);
        CalculateTotal();
    }

    private void CalculateTotal()
    {
        //Total tip
        var totalTip =
            (_bill * _tip) / 100;

        //Tip by person
        var tipByPerson = (totalTip / _noPersons);
        lblTipByPerson.Text = $"{tipByPerson:C}";

        //Subtotal
        var subtotal = (_bill / _noPersons);
        lblSubtotal.Text = $"{subtotal:C}";

        //Total
        var totalByPerson = (_bill + totalTip) / _noPersons;
        lblTotal.Text = $"{totalByPerson:C}";
    }

    private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        _tip = (int)sldTip.Value;
        lblTip.Text = $"Tip: {_tip}%";
        CalculateTotal();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is not Button btn) return;
        var percentage =
            int.Parse(btn.Text.Replace("%", ""));
        sldTip.Value = percentage;
    }

    private void btnMinus_Clicked(object sender, EventArgs e)
    {
        if (_noPersons > 1) _noPersons--;
        lblNoPerons.Text = _noPersons.ToString();
        CalculateTotal();
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        _noPersons++;
        lblNoPerons.Text = _noPersons.ToString();
        CalculateTotal();
    }
}

