using Microsoft.Maui.Controls; // Bu kerakli usullarni import qilish
using AXADIO.Interpreter;

namespace AXADIO.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Application.Current.UserAppTheme = AppTheme.Light;
        }

        public void OnCompilePressed(object sender, EventArgs e)
        {
            string compildecode = kodMaydoni.Text ?? "";
            string[] qatorlar = compildecode.Split('\n');

            var checker = new ExpectingCode();
            checker.CheckCode(qatorlar);

            if (checker.EveryThingIsClear)
            {
                InterpreterObject stringParser = new InterpreterObject();
                string natija = stringParser.Compile(qatorlar);
                myLabel.Text = natija;
            }
            else
            {
                myLabel.Text = "Xatoliklar:\n" + string.Join("\n", checker.Errors);
            }
        }

    }
}
